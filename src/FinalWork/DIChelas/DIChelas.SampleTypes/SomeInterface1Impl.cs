using System;
using System.Threading;

namespace DIChelas.SampleTypes
{
    public class SomeInterface1Impl: ISomeInterface1
    {
        public SomeInterface1Impl() {
        }

        public SomeInterface1Impl(ISomeInterface5 i5)
        {
            throw new NotImplementedException();
        }


    }
}