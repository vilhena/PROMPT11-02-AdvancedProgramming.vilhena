
namespace ChelasInjection.SampleTypes {
    using ChelasInjection.SampleTypes.Attributes;

    public class SomeClass14 {
        public ISomeInterface7 Si7 { get; set; }

        public SomeClass14(ISomeInterface7 si7)
        {
            Si7 = si7;
        }
    }
}