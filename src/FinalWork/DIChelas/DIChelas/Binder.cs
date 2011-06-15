using System;
using System.Collections.Generic;
using DIChelas.Extensions;

namespace DIChelas
{
    public delegate object ResolverHandler(Binder sender, Type t);

    public abstract class Binder
    {
        private Dictionary<Type,Type> _binderMap = new Dictionary<Type, Type>();
        private object _typeBinder;
        
        
        public void Configure()
        {
            InternalConfigure();
        }

        protected abstract void InternalConfigure();


        public event ResolverHandler CustomResolver;


        public ITypeBinder<Target> Bind<Source, Target>()
        {
            _binderMap.AddIfNotContainsKey(typeof(Source), typeof(Target));

            if (_typeBinder == null)
                _typeBinder = new TypeBinder<Target>(_binderMap);

            return (ITypeBinder<Target>) _typeBinder;
        }

        public Type TargetOf(Type sourceType)
        {
            return _binderMap.Value(sourceType);
        }

    }
}