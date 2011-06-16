using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChelasInjection
{
    partial class Binder
    {
        class ActivationBinder<T> : IActivationBinder<T>
        {
            private readonly Binder _binder;

            public ActivationBinder(Binder binder)
            {
                this._binder = binder;
            }

            public ITypeBinder<T> PerRequest()
            {
                this._binder.CurrentConfiguration.ActivationType = ActivationType.PerRequest;
                return new TypeBinder<T>(_binder);
            }

            public ITypeBinder<T> Singleton()
            {
                this._binder.CurrentConfiguration.ActivationType = ActivationType.Singleton;
                return new TypeBinder<T>(_binder);
            }
        }
    }
}
