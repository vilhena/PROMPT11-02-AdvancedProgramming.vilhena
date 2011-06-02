using System;

namespace DIChelas
{
    public delegate object ResolverHandler(Binder sender, Type t);

    public abstract class Binder
    {
        public void Configure()
        {
            throw new NotImplementedException();
        }

        protected abstract void InternalConfigure();


        public event ResolverHandler CustomResolver;

        public ITypeBinder<Target> Bind<Source, Target>()
        {
            throw new NotImplementedException();
        }

    }
}