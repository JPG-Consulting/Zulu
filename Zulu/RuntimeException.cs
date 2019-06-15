using System;
using System.Runtime.Serialization;
using Zulu.Resources;

namespace Zulu
{
    public class RuntimeException : SystemException
    {
        public RuntimeException() 
            : base(CommonResources.RuntimeException_Generic)
        { }

        public RuntimeException(String message) 
            : base(message)
        { }

        public RuntimeException(String message, Exception innerException) 
            : base(message, innerException)
        { }

        protected RuntimeException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        { }
    }
}
