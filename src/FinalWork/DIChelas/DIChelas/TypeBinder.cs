using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DIChelas.Extensions;

namespace DIChelas
{
    public class TypeBinder<T>: ITypeBinder<T>
    {
        private IDictionary<Type, Type> _map;

        public TypeBinder(IDictionary<Type,Type> map)
        {
            _map = map;
        }

        public IConstructorBinder<T> WithConstructor(params Type[] constructorArguments)
        {
            return new ConstructorBinder<T>(_map);
        }

        public ITypeBinder<T> WithNoArgumentsConstructor()
        {
            return this;
        }

        public ITypeBinder<T> WithSingletonActivation()
        {
            return this;
        }

        public ITypeBinder<T> WithPerRequestActivation()
        {
            return this;
        }

        public ITypeBinder<Target> Bind<Source, Target>()
        {
            _map.AddIfNotContainsKey(typeof (Source), typeof (Target));
            return new TypeBinder<Target>(_map);
        }

        public IActivationBinder<T> WithActivation
        {
            get { return new ActivatorBinder<T>(_map); }
            set { throw new NotImplementedException(); }
        }

        public ITypeBinder<T> InitializeObjectWith(Action<T> initialization)
        {
            return this;
        }
    }
}
