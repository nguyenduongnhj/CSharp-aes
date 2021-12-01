using System;
using System.Runtime.Serialization;

namespace AESEngine.Exception
{
    [Serializable]
    internal class IndexOutOfBoundsException : System.Exception
    {
        public IndexOutOfBoundsException()
        {
        }

        public IndexOutOfBoundsException(string message) : base(message)
        {
        }

        public IndexOutOfBoundsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected IndexOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}