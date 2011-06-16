using System;
using System.Runtime.Serialization;

namespace ChelasInjection.Exceptions
{
    [Serializable]
    public class CircularDependencyException : DIChelasException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public CircularDependencyException()
        {
        }

        public CircularDependencyException(string message)
            : base(message)
        {
        }

        public CircularDependencyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CircularDependencyException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}