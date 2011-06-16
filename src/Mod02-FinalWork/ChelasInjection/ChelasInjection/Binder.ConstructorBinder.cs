using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChelasInjection
{
    partial class Binder
    {
        class ConstructorBinder<T> : IConstructorBinder<T>
        {
            private readonly Binder _binder;

            public ConstructorBinder(Binder binder)
            {
                this._binder = binder;
            }

            public ITypeBinder<T> WithValues(Func<object> values)
            {
                this._binder.CurrentConfiguration.ConstructorValues = values;
                return new TypeBinder<T>(_binder);
            }
        }
    }
}
