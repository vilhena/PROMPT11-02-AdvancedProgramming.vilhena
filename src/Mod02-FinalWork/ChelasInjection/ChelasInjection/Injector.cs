using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ChelasInjection.Exceptions;

namespace ChelasInjection
{
    public class Injector
    {
        private readonly Binder _myBinder;
        private readonly Dictionary<Type, object> _sigletonBag = new Dictionary<Type, object>();
        private HashSet<Type> _typesCallResolveStack;
        private Dictionary<Type, object> _requestObjectBag;
        private Dictionary<Type, Expression<Func<Type, Object>>> _executionFuncs =
            new Dictionary<Type, Expression<Func<Type, object>>>();
        private bool _perRequest;


        public Injector(Binder myBinder)
        {
            _myBinder = myBinder;
            _myBinder.Configure();
        }

        public T GetInstance<T>()
        {
            _typesCallResolveStack = new HashSet<Type>();
            SetupPerRequest(typeof (T));

            return (T) ResolveType(typeof (T));
        }

        private object ResolveType(Type type)
        {
            var newObject = ResolveCustomHandler(type); 
            if (newObject != null)
                return newObject;

            newObject = ResolvePerRequestObject(type);
            if (newObject != null)
                return newObject;

            newObject = _myBinder.IsConfigured(type) ? ResolveConfiguredType(type) : ResolveUnConfiguredType(type);

            ResolveCustomInitialization(type, newObject);
            AddPerRequestObject(type, newObject);
            
            return newObject;
        }

        private static object ResolveUnConfiguredType(Type type)
        {
            object newObject = null;
            if (type.GetConstructor(new Type[] { }) == null)
                throw new UnboundTypeException();

            newObject = Activator.CreateInstance(type);
            return newObject;
        }

        private object ResolveConfiguredType(Type type)
        {
            object newObject = null;

            if (_typesCallResolveStack.Contains(type))
                throw new CircularDependencyException();

            _typesCallResolveStack.Add(type);

            var config = _myBinder.Configuration[type];

            switch (config.ConstructorType)
            {
                case ConstructorType.NoArguments:
                    newObject = Activator.CreateInstance(config.Target);
                    break;
                case ConstructorType.Default:
                case ConstructorType.WithCustom:
                    newObject = CreateObjectWithConstructor(config);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
    
            AddIfSingleton(newObject,config);

            _typesCallResolveStack.Remove(type);
            return newObject;
        }

        private void AddIfSingleton(object newObject, ITypeConfiguration config)
        {
            if (config.ActivationType == ActivationType.Singleton)
                _sigletonBag.Add(config.Source, newObject);
        }


        private object ResolvePerRequestObject(Type type)
        {
            if (_perRequest && _requestObjectBag.ContainsKey(type))
                return _requestObjectBag[type];
            return null;
        }

        private void AddPerRequestObject(Type type, object newObject)
        {
            if (_perRequest)
            {
                _requestObjectBag.Add(type, newObject);
            }
        }

        private void SetupPerRequest(Type type)
        {
            _requestObjectBag = new Dictionary<Type, object>();
            _perRequest = false;
            if (_myBinder.IsConfigured(type))
            {
                var config = _myBinder.Configuration[type];

                if (config.ActivationType == ActivationType.PerRequest || config.ActivationType == ActivationType.Singleton)
                    _perRequest = true;
            }
        }

        private object CreateObjectWithConstructor(ITypeConfiguration config)
        {
            var args = config.Constructor.GetParameters().Select(p => GetObject(p, config)).ToArray();
            return Activator.CreateInstance(config.Target, args);
        }

        private object GetObject(ParameterInfo parameterInfo, ITypeConfiguration config)
        {
            object newObject = null;

            newObject = GetValuePropertyFromConstructorValues(parameterInfo, config);

            if(newObject == null)
            {
                newObject = ResolveType(parameterInfo.ParameterType);
            }

            if(newObject == null)
                throw new UnboundTypeException();

            return newObject;
        }

        private static object GetValuePropertyFromConstructorValues(ParameterInfo parameterInfo, ITypeConfiguration config)
        {
            object propObject = null;
            if (config.ConstructorValues != null)
            {
                var customArgs = config.ConstructorValues();
                var valueProperty =
                    customArgs.GetType()
                        .GetProperties()
                        .FirstOrDefault(p => p.PropertyType.Equals(parameterInfo.ParameterType));
                if (valueProperty != null)
                    propObject = valueProperty.GetValue(customArgs, new object[] {});
            }
            return propObject;
        }


        private object ResolveCustomHandler(Type targetType)
        {
            if (_sigletonBag.ContainsKey(targetType))
                return _sigletonBag[targetType];

            var newObj = _myBinder.CustomResolve(targetType);

            if (newObj != null )
            {
                ActivatePerRequest();

                if(_myBinder.IsSingleton(targetType))
                {
                    _sigletonBag.Add(targetType, newObj);
                }

                ResolveCustomInitialization(targetType, newObj);
            }
            return newObj;
        }

        private void ActivatePerRequest()
        {
            _perRequest = true;
        }

        private void ResolveCustomInitialization(Type targetType, object newObj)
        {
            var initialization = _myBinder.GetInitializeObjectWith(targetType);
            if (initialization != null)
                initialization(newObj);
        }

        
    }
}