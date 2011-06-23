using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using ChelasInjection.Attributes;
using ChelasInjection.Cache;
using ChelasInjection.Exceptions;

namespace ChelasInjection
{
    

    internal class TypeResolver
    {
        private readonly Binder _binder;
        private readonly Dictionary<TypeKey, object> _sigletonBag = new Dictionary<TypeKey, object>();
        private HashSet<TypeKey> _typesCallResolveStack;
        private Dictionary<TypeKey, object> _requestObjectBag;
        private bool _perRequest;
        private readonly ExpressionRecorder _recorder;

        private readonly Dictionary<TypeKey, Func<object>> _optimizationCallCache =
            new Dictionary<TypeKey, Func<object>>();

        public TypeResolver(Binder binder)
        {
            _binder = binder;
            _recorder = new ExpressionRecorder();
        }

        public object Resolve(TypeKey type)
        {
            if (_optimizationCallCache.ContainsKey(type))
                return _optimizationCallCache[type]();

            _typesCallResolveStack = new HashSet<TypeKey>();
            SetupPerRequest(type);

            _recorder.Start();

            var newObj = ResolveType(type);

            var exp = _recorder.Result();
            if (exp != null)
            {
                Func<object> method;
                if (_binder.IsSingleton(type))
                    method = () => (newObj);
                else
                    method = (Func<object>)exp.Compile();

                _optimizationCallCache.Add(type, method);
            }

            return newObj;
        }

        private void SetupPerRequest(TypeKey type)
        {
            _requestObjectBag = new Dictionary<TypeKey, object>();
            _perRequest = false;


            if (!_binder.IsConfigured(type)) 
                return;

            var config = _binder.Configuration[type];

            if (config.ActivationType == ActivationType.PerRequest || config.ActivationType == ActivationType.Singleton)
                _perRequest = true;
        }


        private object ResolveType(TypeKey type)
        {
            var newObject = ResolveCustomHandler(type);
            if (newObject != null)
                return newObject;

            newObject = ResolvePerRequestObject(type);
            if (newObject != null)
                return newObject;

            newObject = _binder.IsConfigured(type) ? ResolveConfiguredType(type) : ResolveUnConfiguredType(type);

            ResolveCustomInitialization(type, newObject);
            AddPerRequestObject(type, newObject);

            return newObject;
        }

        private object ResolveCustomHandler(TypeKey targetType)
        {
            if (_sigletonBag.ContainsKey(targetType))
                return _sigletonBag[targetType];

            var newObj = _binder.CustomResolve(targetType.Type);
            if (newObj.Value != null)
            {
                _recorder.CustomResolve(newObj.Key, newObj.Value, _binder, targetType.Type);
                ActivatePerRequest();

                if (_binder.IsSingleton(targetType))
                    _sigletonBag.Add(targetType, newObj.Value);

                ResolveCustomInitialization(targetType, newObj.Value);
            }
            return newObj.Value;
        }

        private object ResolvePerRequestObject(TypeKey type)
        {
            if (_perRequest && _requestObjectBag.ContainsKey(type))
                return _requestObjectBag[type];
            return null;
        }


        private object ResolveUnConfiguredType(TypeKey type)
        {
            object newObject = null;

            //TODO: detect if exists multiple defaults

            if (type.Type.GetConstructors()
                .Where(c =>
                    c.GetCustomAttributes(false).Length >0
                    ).Where(
                    c =>
                    c.GetCustomAttributes(false)[0]
                    .GetType()
                    .Equals(typeof(DefaultConstructorAttribute)))
                    .Count() > 1)
                throw new MultipleDefaultConstructorAttributesException();

            if (type.Type.GetConstructor(new Type[] { }) != null)
            {
                newObject = _recorder.ActivatorCreateInstance(type.Type, _binder.IsSingleton(type));
            }

            if(type.Type.GetConstructors().Length == 0)
                throw new UnboundTypeException();

            //TODO: change this
            var newConfig = new TypeConfiguration(type.Type, type.Type);


            

            newConfig.Constructor = type.Type.GetConstructors()[0];
            newConfig.ConstructorType = ConstructorType.WithCustom;

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

            var config = _binder.Configuration[type];

            switch (config.ConstructorType)
            {
                case ConstructorType.NoArguments:
                    newObject = _recorder.ActivatorCreateInstance(config.Target,
                                                                  _binder.IsSingleton(new TypeKey(config.Source)));
                    break;
                case ConstructorType.Default:
                case ConstructorType.WithCustom:
                    newObject = CreateObjectWithConstructor(config);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            AddIfSingleton(newObject, config);

            _typesCallResolveStack.Remove(type);
            return newObject;
        }


        private void AddIfSingleton(object newObject, ITypeConfiguration config)
        {
            if (config.ActivationType == ActivationType.Singleton)
                _sigletonBag.Add(new TypeKey(config.Source), newObject);
        }

        private void AddPerRequestObject(TypeKey type, object newObject)
        {
            if (_perRequest)
            {
                _requestObjectBag.Add(type, newObject);
            }
        }

        private object CreateObjectWithConstructor(ITypeConfiguration config)
        {
            var args = config.Constructor.GetParameters().Select(p => GetParameterObject(p, config)).ToArray();
            return _recorder.ActivatorCreateInstance(config.Target, args,
                                                     _binder.IsSingleton(new TypeKey(config.Source)));
        }

        private object GetParameterObject(ParameterInfo parameterInfo, ITypeConfiguration config)
        {
            object newObject = null;
            Type parameterAttb = null;

            if (parameterInfo.GetCustomAttributes(false).Length > 0)
                parameterAttb = parameterInfo.GetCustomAttributes(false)[0].GetType();

            newObject = GetValuePropertyFromConstructorValues(parameterInfo, config);
            if(newObject == null)
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

                var customArgs = _recorder.GetConstructorValues(config.ConstructorValues);
                var valueProperty =
                    customArgs.GetType()
                        .GetProperties()
                        .FirstOrDefault(p => p.PropertyType.Equals(parameterInfo.ParameterType));
                if (valueProperty != null)
                    propObject = valueProperty.GetValue(customArgs, new object[] { });
            }
            return propObject;
        }


        private void ActivatePerRequest()
        {
            _perRequest = true;
        }

        private void ResolveCustomInitialization(TypeKey targetType, object newObj)
        {
            var initialization = _binder.GetInitializeObjectWith(targetType);
            if (initialization != null)
                _recorder.InitializeObjectWith(initialization, newObj);
        }



    }
}
