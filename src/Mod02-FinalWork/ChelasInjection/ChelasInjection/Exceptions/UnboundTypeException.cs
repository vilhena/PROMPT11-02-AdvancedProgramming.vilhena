using System;
using System.Runtime.Serialization;

namespace ChelasInjection.Exceptions
{
    [Serializable]
    public class UnboundTypeException : DIChelasException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public UnboundTypeException()
        {
        }

        public UnboundTypeException(string message)
            : base(message)
        {
        }

        public UnboundTypeException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UnboundTypeException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}