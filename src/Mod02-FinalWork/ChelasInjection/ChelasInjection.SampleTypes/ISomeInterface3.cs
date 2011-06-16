namespace ChelasInjection.SampleTypes
{
    public interface ISomeInterface3
    {
        ISomeInterface2 I2 { get;  }
        int P1 { get;  }
        string P3 { get; }
        ISomeInterface1 I1 { get; }
    }
}