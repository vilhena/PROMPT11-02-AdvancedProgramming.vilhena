using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ChelasInjection.ActivationPlugins
{
    class SingletonActivation: IActivationPlugin
    {
        private readonly Dictionary<TypeKey, object> _sigletonBag = new Dictionary<TypeKey, object>();

        static SingletonActivation()
        {
            Instance = new SingletonActivation();
        }

        private SingletonActivation(){ }

        public static SingletonActivation Instance { get; private set; }

        public object GetInstance(TypeKey objectType)
        {
            if (_sigletonBag.ContainsKey(objectType))
                return _sigletonBag[objectType];
            return null;
        }

        public void NewInstance(TypeKey key, object obj)
        {
            if (!_sigletonBag.ContainsKey(key))
                _sigletonBag.Add(key, obj);
        }

        public void BeginRequest(){ }

        public void EndRequest(){ }

        public ExpressionType GetConstructorExpression()
        {
            return ExpressionType.Constant;
        }
    }
}
