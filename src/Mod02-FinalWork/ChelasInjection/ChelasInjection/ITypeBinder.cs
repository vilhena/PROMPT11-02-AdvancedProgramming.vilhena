using System;

namespace ChelasInjection
{
    public interface ITypeBinder<T>
    {
        IConstructorBinder<T> WithConstructor(params Type[] constructorArguments);

        ITypeBinder<T> WithNoArgumentsConstructor();

        ITypeBinder<T> WithSingletonActivation();
        
        ITypeBinder<T> WithPerRequestActivation();

        IActivationBinder<T> WithActivation { get; }
        ITypeBinder<T> InitializeObjectWith(Action<T> initialization);

        void WhenArgumentHas<TAttribute>() where TAttribute : Attribute;
    }
}