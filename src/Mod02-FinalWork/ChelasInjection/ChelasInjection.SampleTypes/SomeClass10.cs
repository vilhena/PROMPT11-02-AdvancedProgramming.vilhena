
using ChelasInjection.Attributes;

namespace ChelasInjection.SampleTypes {
    public class SomeClass10 {
        
        [DefaultConstructor]
        public SomeClass10(ISomeInterface1 si1) { }

        [DefaultConstructor]
        public SomeClass10(ISomeInterface2 si1) { }
    }
}