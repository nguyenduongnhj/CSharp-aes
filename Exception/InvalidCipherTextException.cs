using System;
namespace AESEngine.Exception
{
    public class InvalidCipherTextException : SystemException
    {
        public InvalidCipherTextException(string message) : base(message)
        {
        }
    }
}
