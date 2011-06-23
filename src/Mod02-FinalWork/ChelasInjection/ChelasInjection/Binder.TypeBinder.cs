using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChelasInjection
{
    partial class Binder
    {

        class TypeBinder<T> : ITypeBinder<T>
        {
            private readonly Binder _binder;

            public TypeBinder(Binder binder)
            {
                this._binder = binder;
            }

            public IConstructorBinder<T> WithConstructor(params Type[] constructorArguments)
            {
                this._binder.CurrentConfiguration.ConstructorType = ConstructorType.WithCustom;
                this._binder.CurrentConfiguration.Constructor = typeof (T).GetConstructor(constructorArguments);
                this._binder.CurrentConfiguration.ConstructorArguments = new List<Type>(constructorArguments);
                return new ConstructorBinder<T>(_binder);
            }

            public ITypeBinder<T> WithNoArgumentsConstructor()
            {
                this._binder.CurrentConfiguration.ConstructorType = ConstructorType.NoArguments;
                return this;
            }

            public ITypeBinder<T> WithSingletonActivation()
            {
                this._binder.CurrentConfiguration.ActivationType = ActivationType.Singleton;
                return this;
            }

            public ITypeBinder<T> WithPerRequestActivation()
            {
                this._binder.CurrentConfiguration.ActivationType = ActivationType.PerRequest;
                return this;
            }

            public IActivationBinder<T> WithActivation
            {
                get { return new ActivationBinder<T>(_binder); }
            }

            public ITypeBinder<T> InitializeObjectWith(Action<T> initialization)
            {

                this._binder.CurrentConfiguration.InitializationFunc
                    = (o => initialization((T) o));
                return this;
            }

            public void WhenArgumentHas<TAttribute>() where TAttribute : Attribute
            {
                this._binder.CurrentConfiguration.IsArgumentDependent = true;
                this._binder.CurrentConfiguration.ArgumentType = typeof (TAttribute);
            }
        }

    }
}
