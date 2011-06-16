using System;

namespace ChelasInjection.SampleTypes
{
    public class SomeInterface2Impl : ISomeInterface2
    {
        private ISomeInterface1 _i1;
        private int _someInt = 0;

        public SomeInterface2Impl(ISomeInterface1 i1)
        {
            _i1 = i1;
            SomeStr = "not initialized";
        }

        public ISomeInterface1 I1
        {
            get { return _i1; }
        }

        public int SomeInt
        {
            get { return _someInt; }
        }

        public string SomeStr { get; set; }

        public void SomeInitializatonMethod()
        {
            _someInt = 1;
        }
    }
}