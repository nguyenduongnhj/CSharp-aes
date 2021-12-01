using System;
using System.Runtime.Serialization;

namespace AESEngine.Exception
{
    [Serializable]
    internal class NullPointerException : System.Exception
    {
        public NullPointerException()
        {
        }

        public NullPointerException(string message) : base(message)
        {
        }

        public NullPointerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected NullPointerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}