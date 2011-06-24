using System;
using ChelasInjection.ActivationPlugins;

namespace ChelasInjection
{

    public static class MyActivationExtension
    {
        public static ITypeBinder<T> AllwaysNew<T>(this IActivationBinder<T> activationBinder)
        {
            activationBinder.GetBinder().CurrentConfiguration.ActivationPlugin = new AllwaysNewActivation();
            return new Binder.TypeBinder<T>(activationBinder.GetBinder());
        }
    }

    partial class Binder
    {
        #region Nested type: ActivationBinder

        public class ActivationBinder<T> : IActivationBinder<T>
        {
            private static Binder _binder;

            public ActivationBinder(Binder binder)
            {
                _binder = binder;
            }

            #region IActivationBinder<T> Members

            public ITypeBinder<T> PerRequest()
            {
                _binder.CurrentConfiguration.ActivationPlugin = PerRequestActivation.Instance;
                return new TypeBinder<T>(_binder);
            }

            public ITypeBinder<T> Singleton()
            {
                _binder.CurrentConfiguration.ActivationPlugin = SingletonActivation.Instance;
                return new TypeBinder<T>(_binder);
            }

            public Binder GetBinder()
            {
                return _binder;
            }

            #endregion
        }
        

        #endregion
    }
}