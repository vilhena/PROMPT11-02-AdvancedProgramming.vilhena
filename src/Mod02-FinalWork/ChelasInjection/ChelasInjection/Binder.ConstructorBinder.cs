using System;

namespace ChelasInjection
{
    partial class Binder
    {
        #region Nested type: ConstructorBinder

        public class ConstructorBinder<T> : IConstructorBinder<T>
        {
            private readonly Binder _binder;

            public ConstructorBinder(Binder binder)
            {
                _binder = binder;
            }

            #region IConstructorBinder<T> Members

            public ITypeBinder<T> WithValues(Func<object> values)
            {
                _binder.CurrentConfiguration.ConstructorValues = values;
                return new TypeBinder<T>(_binder);
            }

            #endregion
        }

        #endregion
    }
}