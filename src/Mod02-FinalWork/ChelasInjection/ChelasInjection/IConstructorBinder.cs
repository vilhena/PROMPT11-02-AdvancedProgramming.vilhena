using System;

namespace ChelasInjection
{
    public interface IConstructorBinder<T>
    {
        ITypeBinder<T> WithValues(Func<object> values);
    }
}