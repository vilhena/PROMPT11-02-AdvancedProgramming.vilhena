
namespace ChelasInjection.SampleTypes {
    using ChelasInjection.SampleTypes.Attributes;

    public class SomeClass13 {
        public ISomeInterface7 Si7 { get; set; }

        public SomeClass13([Black] ISomeInterface7 si7)
        {
            Si7 = si7;
        }
    }
}