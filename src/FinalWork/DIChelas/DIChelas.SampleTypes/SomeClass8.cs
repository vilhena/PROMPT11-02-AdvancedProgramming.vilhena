
namespace DIChelas.SampleTypes {
    public class SomeClass8 {
        public SomeClass8() { }

        public SomeClass8(SomeClass6 sc61, SomeClass6 sc62) {
            Sc61 = sc61;
            Sc62 = sc62;
        }

        public SomeClass6 Sc61 { get; private set; }
        public SomeClass6 Sc62 { get; private set; }
    }
}