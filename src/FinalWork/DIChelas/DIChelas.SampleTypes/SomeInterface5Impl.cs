
namespace DIChelas.SampleTypes
{
    public class SomeInterface5Impl : ISomeInterface5
    {
        private ISomeInterface2 _i2;
        private ISomeInterface1 _i1;


        [DefaultConstructor]
        public SomeInterface5Impl(ISomeInterface1 i1)
        {
            _i1 = i1;
        }

        public SomeInterface5Impl(ISomeInterface1 i1, ISomeInterface2 i2)
        {
            _i1 = i1;
            _i2 = i2;
        }

        public SomeInterface5Impl(int i, string str, float f, ISomeInterface1 i1)
        {
        }

        public ISomeInterface2 I2
        {
            get { return _i2; }
        }

        public ISomeInterface1 I1
        {
            get { return _i1; }
        }
    }
}