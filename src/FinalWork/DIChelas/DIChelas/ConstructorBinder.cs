using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIChelas
{
    class ConstructorBinder<T>: IConstructorBinder<T>
    {
        private IDictionary<Type, Type> _map;
        
        public ConstructorBinder(IDictionary<Type,Type> map)
        {
            _map = map;
        }

        public ITypeBinder<T> WithValues(Func<object> values)
        {
            return new TypeBinder<T>(_map);
        }
    }
}
