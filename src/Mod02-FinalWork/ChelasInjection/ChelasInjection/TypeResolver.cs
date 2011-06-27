using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ChelasInjection.ActivationPlugins;
using ChelasInjection.Attributes;
using ChelasInjection.Expressions;
using ChelasInjection.Exceptions;

namespace ChelasInjection
{
    internal class TypeResolver
    {
        private readonly Binder _binder;

        private readonly Dictionary<TypeKey, Func<object>> _optimizationCallCache =
            new Dictionary<TypeKey, Func<object>>();

        private readonly ExpressionRecorder _recorder;

        private HashSet<TypeKey> _typesCallResolveStack;


        public TypeResolver(Binder binder)
        {
            _binder = binder;
            _recorder = new ExpressionRecorder();
        }


        public object Resolve(TypeKey type)
        {
            //Compiled Expression optimization
            if (_optimizationCallCache.ContainsKey(type))
                return _optimizationCallCache[type]();

            _typesCallResolveStack = new HashSet<TypeKey>();

            _binder.ActivationPlugin(type).BeginRequest();
            _recorder.Start();
            var newObj = ResolveType(type);
            _recorder.Stop();
            _binder.ActivationPlugin(type).EndRequest();

            //Gets Recorded Expression
            var exp = _recorder.Result();
            if (exp != null)
            {
                var method = (Func<object>) exp.Compile();
                _optimizationCallCache.Add(type, method);
            }

            return newObj;
        }


        private object ResolveType(TypeKey type)
        {
            // Try using Activation Cache
            object newObject = _binder.ActivationPlugin(type).GetInstance(type);
            if (newObject != null)
                return newObject;

            // Try resolve using CustomHandler
            newObject = ResolveCustomHandler(type);
            if (newObject != null)
                return newObject;

            //Resolve Object
            newObject = _binder.IsConfigured(type) ? ResolveConfiguredType(type) : ResolveUnConfiguredType(type);

            //Aply initialization
            ResolveCustomInitialization(type, newObject);

            _binder.ActivationPlugin(type).NewInstance(type, newObject);

            return newObject;
        }

        private object ResolveCustomHandler(TypeKey targetType)
        {
            KeyValuePair<ResolverHandler, object> newObj = _binder.CustomResolve(targetType.Type);
            if (newObj.Value != null)
            {
                _recorder.CustomResolve(newObj.Key, newObj.Value, _binder, targetType.Type,
                                        _binder.ActivationPlugin(targetType));
                _binder.ActivationPlugin(targetType).NewInstance(targetType, newObj.Value);
                
                ResolveCustomInitialization(targetType, newObj.Value);
            }
            return newObj.Value;
        }

        /// <summary>
        /// Creates one entry on the configuration dictionary
        /// calls the ResolveConfiguredType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private object ResolveUnConfiguredType(TypeKey type)
        {
            object newObject = null;

            if (type.Type.GetConstructors().Length == 0)
                throw new UnboundTypeException();

            var newConfig = new TypeConfiguration(type.Type, type.Type)
                                {
                                    //Constructor = type.Type.GetConstructors()[0],
                                    ConstructorType = ConstructorType.WithCustom,
                                    ActivationPlugin = _binder.ActivationPlugin(type)
                                };

            _binder.Configuration.Add(type, newConfig);
            newObject = ResolveConfiguredType(type);

            return newObject;
        }

        private object ResolveConfiguredType(TypeKey type)
        {
            object newObject = null;

            if (_typesCallResolveStack.Contains(type))
                throw new CircularDependencyException();

            _typesCallResolveStack.Add(type);

            newObject = _binder.ActivationPlugin(type).GetInstance(type);
            if (newObject != null)
                return newObject;

            var config = _binder.Configuration[type];

            //resolves the Constructor just one time
            if (config.Constructor == null)
                FillTypeConstructor(config);

            newObject = CreateObjectWithConstructor(type, config);

            _binder.ActivationPlugin(type).NewInstance(type, newObject);

            _typesCallResolveStack.Remove(type);
            return newObject;
        }

        private void FillTypeConstructor(ITypeConfiguration configuration)
        {
            configuration.ConstructorType = ConstructorType.Default;

            //Multiple DefaultAttributes
            if (configuration.Target.GetConstructors()
                    .Where(c =>
                           c.GetCustomAttributes(false).Length > 0
                    ).Where(
                        c =>
                        c.GetCustomAttributes(false)[0]
                            .GetType()
                            .Equals(typeof (DefaultConstructorAttribute)))
                    .Count() > 1)
                throw new MultipleDefaultConstructorAttributesException();

            //DefaultAttribute
            configuration.Constructor =
                configuration.Target.GetConstructors().Where(
                    c =>
                    c.GetCustomAttributes(false)
                        .Where(a => a.GetType().Equals(typeof (DefaultConstructorAttribute))).FirstOrDefault() != null)
                    .FirstOrDefault();


            if (configuration.Constructor == null)
            {
                //Finds all the constructors that can be binded
                ConstructorInfo[] availableConstructors = configuration.Target.GetConstructors()
                    .Where(constructorInfo => constructorInfo.GetParameters()
                                                  .All(p => TargetTypeIsConfigured(new TypeKey(p.ParameterType)))).
                    ToArray();

                //default ctor with max parameters
                configuration.Constructor =
                    availableConstructors.Where(c => c.GetParameters().Length ==
                                                     availableConstructors.Max(
                                                         x => x.GetParameters().Length))
                        .FirstOrDefault();

                if (configuration.Constructor == null)
                {
                    //Try using the constructor with no parammeters
                    configuration.Constructor = configuration.Target.GetConstructor(new Type[] {});

                    if (configuration.Constructor == null)
                        throw new UnboundTypeException();
                }
            }
        }

        private bool TargetTypeIsConfigured(TypeKey targetType)
        {
            if (_binder.Configuration.ContainsKey(targetType))
                return true;
            if (_binder.Configuration.Values.FirstOrDefault(c => c.Target == targetType.Type) != null)
                return true;

            return false;
        }


        private object CreateObjectWithConstructor(TypeKey key,ITypeConfiguration config)
        {
            var args = config.Constructor.GetParameters().Select(p => GetParameterObject(p, config)).ToArray();

            return _recorder.ActivatorCreateInstance(key, config.Target, args,
                                                     config.ActivationPlugin);
        }

        /// <summary>
        /// Finds the object for each parameter info, if needed resolves type
        /// </summary>
        /// <param name="parameterInfo"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        private object GetParameterObject(ParameterInfo parameterInfo, ITypeConfiguration config)
        {
            object newObject = null;
            Type parameterAttb = null;

            if (parameterInfo.GetCustomAttributes(false).Length > 0)
                parameterAttb = parameterInfo.GetCustomAttributes(false)[0].GetType();

            newObject = GetValuePropertyFromConstructorValues(parameterInfo, config);
            if (newObject == null)
            {
                if (_binder.IsConfigured(new TypeKey(parameterInfo.ParameterType, parameterAttb)))
                    newObject = ResolveType(new TypeKey(parameterInfo.ParameterType, parameterAttb));
                else if (_binder.IsConfigured(new TypeKey(parameterInfo.ParameterType)))
                    newObject = ResolveType(new TypeKey(parameterInfo.ParameterType));
                else
                    throw new NotImplementedException("CANNOT RESOLVE PARAMETER");
            }

            if (newObject == null)
                throw new UnboundTypeException();

            return newObject;
        }

        private object GetValuePropertyFromConstructorValues(ParameterInfo parameterInfo, ITypeConfiguration config)
        {
            object propObject = null;
            if (config.ConstructorValues != null)
            {
                object customArgs = _recorder.GetConstructorValues(config.ConstructorValues);
                PropertyInfo valueProperty =
                    customArgs.GetType()
                        .GetProperties()
                        .FirstOrDefault(p => p.PropertyType.Equals(parameterInfo.ParameterType));
                if (valueProperty != null)
                    propObject = valueProperty.GetValue(customArgs, new object[] {});
            }
            return propObject;
        }


        private void ResolveCustomInitialization(TypeKey targetType, object newObj)
        {
            var initialization = _binder.GetInitializeObjectWith(targetType);
            if (initialization != null)
                _recorder.InitializeObjectWith(initialization, newObj);
        }
    }
}