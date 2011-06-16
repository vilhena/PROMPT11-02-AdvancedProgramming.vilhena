namespace ChelasInjection.SampleTypes
{
    public interface ISomeInterface2
    {

        ISomeInterface1 I1 { get;}
        int SomeInt { get; }
        string SomeStr { get; set; }
        void SomeInitializatonMethod();
    }
}