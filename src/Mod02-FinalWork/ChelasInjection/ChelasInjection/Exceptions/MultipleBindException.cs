namespace ChelasInjection.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class MultipleBindException : ChelasInjectionException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public MultipleBindException()
        {
        }

        public MultipleBindException(string message)
            : base(message)
        {
        }

        public MultipleBindException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected MultipleBindException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}