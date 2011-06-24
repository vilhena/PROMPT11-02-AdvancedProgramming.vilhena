using System;

namespace ChelasInjection
{
    public interface ITypeBinder<T>
    {
        IActivationBinder<T> WithActivation { get; }
        IConstructorBinder<T> WithConstructor(params Type[] constructorArguments);

        ITypeBinder<T> WithNoArgumentsConstructor();

        ITypeBinder<T> WithSingletonActivation();

        ITypeBinder<T> WithPerRequestActivation();

        ITypeBinder<T> InitializeObjectWith(Action<T> initialization);

        void WhenArgumentHas<TAttribute>() where TAttribute : Attribute;
    }
}