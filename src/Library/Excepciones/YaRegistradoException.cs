using System;
using System.Runtime.Serialization;

namespace Library
{
    public class YaRegistradoException : Exception 
    {
        public YaRegistradoException()
        {
        }

        public YaRegistradoException(string message)
        : base(message)
        {
        }

        public YaRegistradoException(string message, Exception innerException)
        : base(message, innerException)
        {
        }

        protected YaRegistradoException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
        

    }
}
