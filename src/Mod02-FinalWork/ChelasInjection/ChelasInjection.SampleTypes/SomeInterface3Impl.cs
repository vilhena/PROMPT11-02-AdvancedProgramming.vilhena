namespace ChelasInjection.SampleTypes
{
    public class SomeInterface3Impl : ISomeInterface3
    {
        private ISomeInterface2 _i2;
        private int _p1;
        private string _p3;
        private ISomeInterface1 _i1;

        public SomeInterface3Impl()
        {
        }


        public SomeInterface3Impl(int p1, ISomeInterface2 i2, ISomeInterface1 i1, string p3)
        {
            _i1 = i1;
            _p3 = p3;
            _p1 = p1;
            _i2 = i2;
        }

        public ISomeInterface2 I2
        {
            get { return _i2; }

        }

        public int P1
        {
            get { return _p1; }
        }

        public string P3
        {
            get { return _p3; }
        }

        public ISomeInterface1 I1
        {
            get { return _i1; }
        }
    }
}