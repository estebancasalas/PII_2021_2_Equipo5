using System;
using System.Runtime.Serialization;

namespace Library
{
    [Serializable]
    public class OpcionInvalidaException : Exception
    {
        public OpcionInvalidaException()
        {
        }

        public OpcionInvalidaException(string message)
        : base(message)
        {
        }

        public OpcionInvalidaException(string message, Exception innerException)
        : base(message, innerException)
        {
        }

        protected OpcionInvalidaException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
    }
}