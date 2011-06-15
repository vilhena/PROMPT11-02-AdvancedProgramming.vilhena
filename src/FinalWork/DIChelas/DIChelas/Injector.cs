using System;

namespace DIChelas
{
    public class Injector
    {
        private Binder _myBinder;

        public Injector(Binder myBinder)
        {
            _myBinder = myBinder;
            _myBinder.Configure();
        }

        public T GetInstance<T>()
        {
            Type target = _myBinder.TargetOf(typeof(T));
            return (T) Activator.CreateInstance(target);
        }
    }
}