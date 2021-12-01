using System;
namespace AESEngine.Exception
{
    public class DataLengthException : SystemException
    {
        public DataLengthException(string message) : base(message)
        {
        }
    }
}
