using System;

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
            return (T) _myResolver.Resolve(new TypeKey(typeof (T)));
        }

        public T GetInstance<T, TA>() where TA : Attribute
        {
            return (T) _myResolver.Resolve(new TypeKey(typeof (T), typeof (TA)));
        }

        public T GetInstance<T>(string name)
        {
            throw new NotImplementedException();
        }
    }
}