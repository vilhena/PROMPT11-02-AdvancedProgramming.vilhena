using System;

namespace DIChelas {
    public interface IConstructorBinder<T> {
        ITypeBinder<T> WithValues(Func<object> values);
    }
}