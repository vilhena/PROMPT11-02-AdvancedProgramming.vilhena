
namespace ChelasInjection.SampleTypes {
    using ChelasInjection.SampleTypes.Attributes;

    public class SomeClass11 {
        public ISomeInterface7 Si7 { get; set; }

        public SomeClass11([Red] ISomeInterface7 si7)
        {
            Si7 = si7;
        }
    }
}