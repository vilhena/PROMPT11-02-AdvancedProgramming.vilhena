
namespace ChelasInjection.SampleTypes {
    public class SomeClass7 {
        public SomeClass7() { }

        public SomeClass7(SomeClass6 sc6, SomeClass6 sc62) {
            Sc6 = sc6;
        }

        public SomeClass6 Sc6 { get; private set; }
    }
}