using System;
using AESEngine.Exception;

namespace AESEngine.Utils
{
    public class CBCBlockCipher
    {
        private byte[] IV;
        private byte[] cbcV;
        private byte[] cbcNextV;

        private int blockSize;
        private AESEngine cipher = null;
        private bool encrypting;

        public CBCBlockCipher(AESEngine cipher) {
            this.cipher = cipher;
            this.blockSize = cipher.getBlockSize();
            this.IV = new byte[blockSize];
            this.cbcV = new byte[blockSize];
            this.cbcNextV = new byte[blockSize];
        }

        public void init(bool encrypting, byte[] iv) {
            bool oldEncrypting = this.encrypting;

            this.encrypting = encrypting;
            if (iv.Length != blockSize) {
                throw new IllegalArgumentException("initialisation vector must be the same length as block size");
            }

            Array.Copy(iv, 0, IV, 0, iv.Length);

            reset();
        }

         
        public int processBlock( byte[] input, int inOff, byte[] output, int outOff) {
            return (encrypting) ? encryptBlock(input, inOff, output, outOff) : decryptBlock(input, inOff, output, outOff);
        }


        public void reset() {
            Array.Copy(IV, 0, cbcV, 0, IV.Length);
           // Arrays.fill(cbcNextV, (byte)0); 
            cipher.reset();
        }

        private int encryptBlock( byte[] input, int inOff, byte[] output, int outOff) {
                if ((inOff + blockSize) > input.Length) {
                    throw new DataLengthException("input buffer too short");
                }

                /*
                 * XOR the cbcV and the input,
                 * then encrypt the cbcV
                 */
                for (int i = 0; i < blockSize; i++)
                {
                    cbcV[i] ^= input[inOff +i];
                }

                int length = cipher.processBlock(cbcV, 0, output, outOff);
                Array.Copy(output, outOff, cbcV, 0, cbcV.Length);

                return length;
        }

        private int decryptBlock( byte[] input, int inOff, byte[] output, int outOff) {
            if ((inOff + blockSize) > input.Length) {
                throw new DataLengthException("input buffer too short");
            }

            Array.Copy(input, inOff, cbcNextV, 0, blockSize);

            int length = cipher.processBlock(input, inOff, output, outOff);


            // XOR the cbcV and the output

            for (int i = 0; i < blockSize; i++) {
                    output[outOff +i] ^= cbcV[i];
            }

            byte[] tmp;

            tmp = cbcV;
            cbcV = cbcNextV;
            cbcNextV = tmp;

            return length;
        }
    }

}