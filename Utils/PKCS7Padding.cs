using System;
using AESEngine.Exception;

namespace AESEngine.Utils
{
	public class PKCS7Padding
	{
		public PKCS7Padding()
		{
		}

        public int addPadding(
           byte[]  input,
           int inOff)
        {
            byte code = (byte)(input.Length - inOff);

            while (inOff < input.Length)
        {
                input[inOff] = code;
                inOff++;
            }

            return code;
        }


        public int padCount(byte[] input) 
        {
          int count = input[input.Length - 1] & 0xff;
            byte countAsbyte = (byte)count;

            // constant time version
            bool failed = (count > input.Length | count == 0);

            for (int i = 0; i<input.Length; i++)
            {
                failed |= (input.Length - i <= count) & (input[i] != countAsbyte);
            }

            if (failed)
            {
                throw new InvalidCipherTextException("pad block corrupted");
            }

            return count;
     }
	}
}
