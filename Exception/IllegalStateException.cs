using System;
using System.Runtime.Serialization;

namespace AESEngine.Exception
{
    [Serializable]
    internal class IllegalStateException : System.Exception
    {
        public IllegalStateException()
        {
        }

        public IllegalStateException(string message) : base(message)
        {
        }

        public IllegalStateException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}