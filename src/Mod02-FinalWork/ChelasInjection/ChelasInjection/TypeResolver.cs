using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using ChelasInjection.Cache;
using ChelasInjection.Exceptions;

namespace ChelasInjection
{
    internal class TypeResolver
    {
        private readonly Binder _binder;
        private readonly Dictionary<Type, object> _sigletonBag = new Dictionary<Type, object>();
        private HashSet<Type> _typesCallResolveStack;
        private Dictionary<Type, object> _requestObjectBag;
        private bool _perRequest;
        private readonly ExpressionRecorder _recorder;

        private readonly Dictionary<Type, Func<object>> _optimizationCallCache =
            new Dictionary<Type, Func<object>>();

        public TypeResolver(Binder binder)
        {
            _binder = binder;
            _recorder = new ExpressionRecorder();
        }

        public object Resolve(Type type)
        {
            if (_optimizationCallCache.ContainsKey(type))
                return _optimizationCallCache[type]();

            _typesCallResolveStack = new HashSet<Type>();
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

        private void SetupPerRequest(Type type)
        {
            _requestObjectBag = new Dictionary<Type, object>();
            _perRequest = false;
            
            if (!_binder.IsConfigured(type)) 
                return;

            var config = _binder.Configuration[type];

            if (config.ActivationType == ActivationType.PerRequest || config.ActivationType == ActivationType.Singleton)
                _perRequest = true;
        }


        private object ResolveType(Type type)
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

        private object ResolveCustomHandler(Type targetType)
        {
            if (_sigletonBag.ContainsKey(targetType))
                return _sigletonBag[targetType];

            var newObj = _binder.CustomResolve(targetType);
            if (newObj.Value != null)
            {
                _recorder.CustomResolve(newObj.Key, newObj.Value, _binder, targetType);
                ActivatePerRequest();

                if (_binder.IsSingleton(targetType))
                    _sigletonBag.Add(targetType, newObj.Value);

                ResolveCustomInitialization(targetType, newObj.Value);
            }
            return newObj.Value;
        }

        private object ResolvePerRequestObject(Type type)
        {
            if (_perRequest && _requestObjectBag.ContainsKey(type))
                return _requestObjectBag[type];
            return null;
        }


        private object ResolveUnConfiguredType(Type type)
        {
            object newObject = null;
            if (type.GetConstructor(new Type[] { }) == null)
                throw new UnboundTypeException();

            newObject = _recorder.ActivatorCreateInstance(type, _binder.IsSingleton(type));
            return newObject;
        }

        private object ResolveConfiguredType(Type type)
        {
            object newObject = null;

            if (_typesCallResolveStack.Contains(type))
                throw new CircularDependencyException();

            _typesCallResolveStack.Add(type);

            var config = _binder.Configuration[type];

            switch (config.ConstructorType)
            {
                case ConstructorType.NoArguments:
                    newObject = _recorder.ActivatorCreateInstance(config.Target, _binder.IsSingleton(config.Source));
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
                _sigletonBag.Add(config.Source, newObject);
        }

        private void AddPerRequestObject(Type type, object newObject)
        {
            if (_perRequest)
            {
                _requestObjectBag.Add(type, newObject);
            }
        }

        private object CreateObjectWithConstructor(ITypeConfiguration config)
        {
            var args = config.Constructor.GetParameters().Select(p => GetParameterObject(p, config)).ToArray();
            return _recorder.ActivatorCreateInstance(config.Target, args, _binder.IsSingleton(config.Source));
        }

        private object GetParameterObject(ParameterInfo parameterInfo, ITypeConfiguration config)
        {
            object newObject = null;

            newObject = GetValuePropertyFromConstructorValues(parameterInfo, config) ??
                        ResolveType(parameterInfo.ParameterType);

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

        private void ResolveCustomInitialization(Type targetType, object newObj)
        {
            var initialization = _binder.GetInitializeObjectWith(targetType);
            if (initialization != null)
                _recorder.InitializeObjectWith(initialization, newObj);
        }



    }
}
