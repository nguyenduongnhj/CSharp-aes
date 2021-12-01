using System;
using System.Runtime.Serialization;

namespace AESEngine.Exception
{
    [Serializable]
    internal class IllegalArgumentException : System.Exception
    {
        public IllegalArgumentException()
        {
        }

        public IllegalArgumentException(string message) : base(message)
        {
        }

        public IllegalArgumentException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected IllegalArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}