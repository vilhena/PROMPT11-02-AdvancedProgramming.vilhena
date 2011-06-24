using System;
using System.Collections.Generic;
using ChelasInjection.ActivationPlugins;

namespace ChelasInjection
{
    partial class Binder
    {
        #region Nested type: TypeBinder

        public class TypeBinder<T> : ITypeBinder<T>
        {
            private readonly Binder _binder;

            public TypeBinder(Binder binder)
            {
                _binder = binder;
            }

            #region ITypeBinder<T> Members

            public IConstructorBinder<T> WithConstructor(params Type[] constructorArguments)
            {
                _binder.CurrentConfiguration.ConstructorType = ConstructorType.WithCustom;
                _binder.CurrentConfiguration.Constructor = typeof (T).GetConstructor(constructorArguments);
                _binder.CurrentConfiguration.ConstructorArguments = new List<Type>(constructorArguments);
                return new ConstructorBinder<T>(_binder);
            }

            public ITypeBinder<T> WithNoArgumentsConstructor()
            {
                _binder.CurrentConfiguration.ConstructorType = ConstructorType.NoArguments;
                _binder.CurrentConfiguration.Constructor =
                    _binder.CurrentConfiguration.Target.GetConstructor(new Type[] {});
                return this;
            }

            public ITypeBinder<T> WithSingletonActivation()
            {
                _binder.CurrentConfiguration.ActivationPlugin = SingletonActivation.Instance;
                return this;
            }

            public ITypeBinder<T> WithPerRequestActivation()
            {
                _binder.CurrentConfiguration.ActivationPlugin = PerRequestActivation.Instance;
                return this;
            }

            public IActivationBinder<T> WithActivation
            {
                get { return new ActivationBinder<T>(_binder); }
            }

            public ITypeBinder<T> InitializeObjectWith(Action<T> initialization)
            {
                _binder.CurrentConfiguration.InitializationFunc
                    = (o => initialization((T) o));
                return this;
            }

            public void WhenArgumentHas<TAttribute>() where TAttribute : Attribute
            {
                _binder.CurrentConfiguration.IsArgumentDependent = true;
                _binder.CurrentConfiguration.ArgumentType = typeof (TAttribute);
            }

            #endregion
        }

        #endregion
    }
}