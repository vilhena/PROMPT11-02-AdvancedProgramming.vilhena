namespace DIChelas
{
    public interface IActivationBinder<T>
    {
        ITypeBinder<T> PerRequest { get; set; }
        ITypeBinder<T> Singleton { get; set; }
    }
}