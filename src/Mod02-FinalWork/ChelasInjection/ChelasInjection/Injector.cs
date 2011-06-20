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
        private readonly TypeResolver _myResolver;
        
        public Injector(Binder myBinder)
        {
            _myBinder = myBinder;
            _myBinder.Configure();
            _myResolver = new TypeResolver(_myBinder);
        }

        public T GetInstance<T>()
        {
            return (T) _myResolver.Resolve(typeof (T));
        }
        
    }
}