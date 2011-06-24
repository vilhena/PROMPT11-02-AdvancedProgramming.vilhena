using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ChelasInjection.ActivationPlugins
{
    class PerRequestActivation : IActivationPlugin
    {
        private Dictionary<TypeKey, object> _requestObjectBag;

        static PerRequestActivation()
        {
            Instance = new PerRequestActivation();
        }

        private PerRequestActivation(){ }

        public static PerRequestActivation Instance { get; private set; }

        public object GetInstance(TypeKey objectType)
        {
            if(_requestObjectBag == null)
                BeginRequest();

            if (_requestObjectBag.ContainsKey(objectType))
                return _requestObjectBag[objectType];
            return null;
        }

        public void NewInstance(TypeKey key, object obj)
        {
            if (!_requestObjectBag.ContainsKey(key))
                _requestObjectBag.Add(key, obj);
        }

        public void BeginRequest()
        {
            _requestObjectBag = new Dictionary<TypeKey, object>();
        }

        public void EndRequest(){ }
        public ExpressionType GetConstructorExpression()
        {
            return ExpressionType.New;
        }
    }
}
