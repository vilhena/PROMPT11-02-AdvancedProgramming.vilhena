
namespace ChelasInjection.SampleTypes {
    using ChelasInjection.SampleTypes.Attributes;

    public class SomeClass12 {
        public ISomeInterface7 Si7 { get; set; }

        public SomeClass12([Yellow] ISomeInterface7 si7)
        {
            Si7 = si7;
        }
    }
}