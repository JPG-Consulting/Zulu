using System;
using System.Runtime.Serialization;
using Zulu.Resources;

namespace Zulu.Data
{
    public class DataException : RuntimeException
    {
        public DataException() 
            : base(DataResources.DataException_Generic)
        { }

        public DataException(String message) 
            : base(message)
        { }

        public DataException(String message, Exception innerException) 
            : base(message, innerException)
        { }

        protected DataException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        { }
    }
}
