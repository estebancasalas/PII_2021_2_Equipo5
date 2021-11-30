using System;
using System.Runtime.Serialization;

namespace Library
{
    public class SinPermisoException : Exception
    {
        public SinPermisoException()
        {
        }

        public SinPermisoException(string message)
        : base(message)
        {
        }

        public SinPermisoException(string message, Exception innerException)
        : base(message, innerException)
        {
        }

        protected SinPermisoException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
        }
        

    }
}
