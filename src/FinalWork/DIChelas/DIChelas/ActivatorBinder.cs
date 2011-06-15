using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DIChelas
{
    class ActivatorBinder<T>: IActivationBinder<T>
    {
        private readonly TypeBinder<T> _perRequest;
        private readonly TypeBinder<T> _singleton;
        private IDictionary<Type, Type> _map;

        public ActivatorBinder(IDictionary<Type,Type> map)
        {
            _map = map;
            _perRequest = new TypeBinder<T>(map);
            _singleton = new TypeBinder<T>(map);
        }

        public ITypeBinder<T> PerRequest
        {
            get { return _perRequest; }
            set { throw new NotImplementedException(); }
        }

        public ITypeBinder<T> Singleton
        {
            get { return _singleton; }
            set { throw new NotImplementedException(); }
        }
    }
}
