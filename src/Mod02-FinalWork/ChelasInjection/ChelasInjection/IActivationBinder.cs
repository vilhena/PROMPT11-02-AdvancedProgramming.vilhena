namespace ChelasInjection
{
    public interface IActivationBinder<T>
    {
        ITypeBinder<T> PerRequest();
        ITypeBinder<T> Singleton();
    }
}