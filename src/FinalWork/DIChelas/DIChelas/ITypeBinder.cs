using System;

namespace DIChelas
{
    public interface ITypeBinder<T>
    {
        IConstructorBinder<T> WithConstructor(params Type[] constructorArguments);

        ITypeBinder<T> WithNoArgumentsConstructor();

        ITypeBinder<T> WithSingletonActivation();
        
        ITypeBinder<T> WithPerRequestActivation();

        ITypeBinder<Target> Bind<Source, Target>();
        IActivationBinder<T> WithActivation { get; set; }
        ITypeBinder<T> InitializeObjectWith(Action<T> initialization);
    }
}