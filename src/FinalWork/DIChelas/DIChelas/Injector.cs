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
            throw new NotImplementedException();
        }
    }
}