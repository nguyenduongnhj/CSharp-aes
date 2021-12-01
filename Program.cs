using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using AESEngine.Exception;
using AESEngine.Utils;

namespace AESEngine
{
    class MainClass
    {
        private static long nanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }

        public static void Main(string[] args)
        {
            var main = new MainClass();
            main.testCBC();
            main.normal();
        }


        public void testCBC()
        {
            byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            byte[] dat = Encoding.ASCII.GetBytes(File.ReadAllText("input.txt"));
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
             
            byte[] output = encryptCBC(dat, key, iv);

            File.WriteAllBytes("ouput.enc", output);

            byte[] decryptResult = decryptCBC(output, key, iv);

            File.WriteAllBytes("ouput.txt", decryptResult);
        }


        public byte[] encryptCBC(byte[] dat, byte[] key, byte[] iv)
        {

            Console.Write("===== Mã hóa CBC =====");

            AESEngine engine = new AESEngine();
            PKCS7Padding padding = new PKCS7Padding();
            CBCBlockCipher block = new CBCBlockCipher(engine);
            block.init(true, iv);

            int length = engine.getBlockSize() - (dat.Length % engine.getBlockSize());
            int dataSize = length + dat.Length;
            engine.init(true, key);

            byte[] output = new byte[dataSize];

            //tg bat dau ma hoa
            long startTime = nanoTime();


            byte[] paddingData = new byte[dataSize];
            Array.Copy(dat, 0, paddingData, 0, dat.Length);
            padding.addPadding(paddingData, dat.Length);

            int count = paddingData.Length / engine.getBlockSize();


            for (int i = 0; i < count; i++)
            {
                block.processBlock(paddingData, i * engine.getBlockSize(), output, i * engine.getBlockSize());
            }

            //ket thuc ma hoa
            long durationEncTime = nanoTime() - startTime;
            Console.Write("[-] Duration encrypt: " + durationEncTime + " nano second");

            Console.Write("[.] Padding data : 0x");
            for (int i = 0; i < paddingData.Length; i++)
            { 
                string bufstring = String.Format("{0:X2}", paddingData[i]);
                Console.Write(bufstring);
            }

            Console.Write("\n[.] Encrypt data output: 0x");
            for (int i = 0; i < output.Length ; i++) {  
                string bufstring = String.Format("{0:X2}", output[i]);
                Console.Write(bufstring);
            }
            Console.Write("\n");
            return output;
        }


        public byte[] decryptCBC(byte[] dat, byte[] key, byte[] iv)
        {

            Console.Write("===== Giải mã CBC =====");

            AESEngine engine = new AESEngine();
            PKCS7Padding padding = new PKCS7Padding();
            CBCBlockCipher block = new CBCBlockCipher(engine);
            block.init(false, iv);
            int dataSize = dat.Length;
            byte[] decrypt = new byte[dataSize];
            engine.init(false, key);


            int count = dataSize / engine.getBlockSize();


            //tg bat dau giai ma~
            long startTime = nanoTime();



            for (int i = 0; i < count; i++)
            {
                block.processBlock(dat, i * engine.getBlockSize(), decrypt, i * engine.getBlockSize());
            }

            //        engine.processBlock(out,0,decrypt,0);

            int paddingCount = padding.padCount(decrypt);

            byte[] decryptResult = new byte[decrypt.Length - paddingCount];

            Array.Copy(decrypt, 0, decryptResult, 0, decryptResult.Length);

            long durationDecTime = nanoTime() - startTime;
            Console.Write("[-] Duration decrypt: " + durationDecTime + " nano second");


            Console.Write("\n[.] Decrypt data output: 0x");
            for (int i = 0; i < decryptResult.Length; i++)
            { 
                string bufstring = String.Format("{0:X2}", decryptResult[i]);
                Console.Write(bufstring);
            }
            Console.Write("\n[.] String result: " + System.Text.Encoding.Default.GetString(decryptResult));
            return decryptResult;
        }


        public void normal()
        {
            AESEngine engine = new AESEngine();
            PKCS7Padding padding = new PKCS7Padding();

            //key + data
            byte[] key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            byte[] dat = Encoding.ASCII.GetBytes("Pham hieu dep trai vo dich");

            //calc padding length
            int paddingLength = engine.getBlockSize() - (dat.Length % engine.getBlockSize());
            int dataSize = paddingLength + dat.Length;

            byte[] output = new byte[dataSize];
            byte[] decrypt = new byte[dataSize];
            byte[] paddingData = new byte[dataSize];

            /// START ENCRYPT

            engine.init(true, key);
            //tg bat dau ma hoa
            long startTime = nanoTime();

            //pkcs7 padding  
            Array.Copy(dat, 0, paddingData, 0, dat.Length);
            padding.addPadding(paddingData, dat.Length);

            // calc loop count
            int count = paddingData.Length / engine.getBlockSize();
            for (int i = 0; i < count; i++)
            {
                engine.processBlock(paddingData, i * engine.getBlockSize(), output, i * engine.getBlockSize());
            }

            //end encrypt + padding
            long durationEncTime = nanoTime() - startTime;
            Console.WriteLine("[-] Duration encrypt: " + durationEncTime + " (nano second)");
            Console.Write("[.] Padding data : 0x");
            for (int i = 0; i < paddingData.Length; i++)
            {
                string bufstring = String.Format("{0:X2}", paddingData[i]);
                Console.Write(bufstring);
            }
            Console.Write("\n[.] Encrypt data output: 0x");
            for (int i = 0; i < output.Length; i++)
            {
                string bufstring = String.Format("{0:X2}", output[i]);
                Console.Write(bufstring);
            }

            /// START DECRYPT

            engine.init(false, key);
            //tg bat dau giai ma~
            startTime = nanoTime();

            for (int i = 0; i < count; i++)
            {
                engine.processBlock(output, i * engine.getBlockSize(), decrypt, i * engine.getBlockSize());
            }

            // unpadding
            int paddingCount = padding.padCount(decrypt);
            byte[] decryptResult = new byte[decrypt.Length - paddingCount];
            Array.Copy(decrypt, 0, decryptResult, 0, decryptResult.Length);

            // end decrypt + unpadding
            long durationDecTime = nanoTime() - startTime;
            Console.Write("\n[-] Duration decrypt: " + durationDecTime + " (nano second)");
            Console.Write("\n[.] Decrypt data output: 0x");
            for (int i = 0; i < decryptResult.Length; i++)
            {
                string bufstring = String.Format("{0:X2}", decryptResult[i]);
                Console.Write(bufstring);
            }

            Console.WriteLine("\n[.] String result: " + System.Text.Encoding.Default.GetString(decryptResult));
        }


    }
}
