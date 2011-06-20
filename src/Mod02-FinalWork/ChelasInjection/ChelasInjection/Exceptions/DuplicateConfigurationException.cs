namespace ChelasInjection.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class DuplicateConfigurationException : ChelasInjectionException
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public DuplicateConfigurationException()
        {
        }

        public DuplicateConfigurationException(string message)
            : base(message)
        {
        }

        public DuplicateConfigurationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DuplicateConfigurationException(
            SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}