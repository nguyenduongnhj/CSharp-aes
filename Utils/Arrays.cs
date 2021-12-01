using System;
using AESEngine.Exception;

namespace AESEngine.Utils
{
    public class Arrays
    {
        public Arrays()
        {
        }

        public static bool areAllZeroes(byte[] buf, int off, int len)
        {
            int bits = 0;
            for (int i = 0; i < len; ++i)
            {
                bits |= buf[off + i];
            }
            return bits == 0;
        }

        public static bool areEqual(bool[] a, bool[] b)
        {
            
            return Arrays.Equals(a, b);
        }

        public static bool areEqual(byte[] a, byte[] b)
        {
            return Arrays.Equals(a, b);
        }

        public static bool areEqual(byte[] a, int aFromIndex, int aToIndex, byte[] b, int bFromIndex, int bToIndex)
        {
            int aLength = aToIndex - aFromIndex;
            int bLength = bToIndex - bFromIndex;

            if (aLength != bLength)
            {
                return false;
            }

            for (int i = 0; i < aLength; ++i)
            {
                if (a[aFromIndex + i] != b[bFromIndex + i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool areEqual(char[] a, char[] b)
        {
            return Arrays.Equals(a, b);
        }

        public static bool areEqual(int[] a, int[] b)
        {
            return Arrays.Equals(a, b);
        }

        public static bool areEqual(long[] a, long[] b)
        {
            return Arrays.Equals(a, b);
        }

        public static bool areEqual(Object[] a, Object[] b)
        {
            return Arrays.Equals(a, b);
        }

        public static bool areEqual(short[] a, short[] b)
        {
            return Arrays.Equals(a, b);
        }

        /**
         * A constant time equals comparison - does not terminate early if
         * test will fail. For best results always pass the expected value
         * as the first parameter.
         *
         * @param expected first array
         * @param supplied second array
         * @return true if arrays equal, false otherwise.
         */
        public static bool constantTimeAreEqual(
                byte[] expected,
                byte[] supplied)
        {
            if (expected == null || supplied == null)
            {
                return false;
            }

            if (expected == supplied)
            {
                return true;
            }

            int len = (expected.Length < supplied.Length) ? expected.Length : supplied.Length;

            int nonEqual = expected.Length ^ supplied.Length;

            for (int i = 0; i != len; i++)
            {
                nonEqual |= (expected[i] ^ supplied[i]);
            }
            for (int i = len; i < supplied.Length; i++)
            {
                nonEqual |= (supplied[i] ^ ~supplied[i]);
            }

            return nonEqual == 0;
        }

        public static bool constantTimeAreEqual(int len, byte[] a, int aOff, byte[] b, int bOff)
        {
            if (null == a)
            {
                throw new NullPointerException("'a' cannot be null");
            }
            if (null == b)
            {
                throw new NullPointerException("'b' cannot be null");
            }
            if (len < 0)
            {
                throw new IllegalArgumentException("'len' cannot be negative");
            }
            if (aOff > (a.Length - len))
            {
                throw new IndexOutOfBoundsException("'aOff' value invalid for specified length");
            }
            if (bOff > (b.Length - len))
            {
                throw new IndexOutOfBoundsException("'bOff' value invalid for specified length");
            }

            int d = 0;
            for (int i = 0; i < len; ++i)
            {
                d |= (a[aOff + i] ^ b[bOff + i]);
            }
            return 0 == d;
        }

        public static int compareUnsigned(byte[] a, byte[] b)
        {
            if (a == b)
            {
                return 0;
            }
            if (a == null)
            {
                return -1;
            }
            if (b == null)
            {
                return 1;
            }
            int minLen = Math.Min(a.Length, b.Length);
            for (int i = 0; i < minLen; ++i)
            {
                int aVal = a[i] & 0xFF, bVal = b[i] & 0xFF;
                if (aVal < bVal)
                {
                    return -1;
                }
                if (aVal > bVal)
                {
                    return 1;
                }
            }
            if (a.Length < b.Length)
            {
                return -1;
            }
            if (a.Length > b.Length)
            {
                return 1;
            }
            return 0;
        }

        public static bool contains(bool[] a, bool val)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool contains(byte[] a, byte val)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool contains(char[] a, char val)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool contains(int[] a, int val)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool contains(long[] a, long val)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool contains(short[] a, short val)
        {
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] == val)
                {
                    return true;
                }
            }
            return false;
        }

        public static void fill(bool[] a, bool val)
        {
            
            Arrays.fill(a, val);
        }

        public static void fill(bool[] a, int fromIndex, int toIndex, bool val)
        {
            Arrays.fill(a, fromIndex, toIndex, val);
        }

        public static void fill(byte[] a, byte val)
        {
            Arrays.fill(a, val);
        }

        public static void fill(byte[] a, int fromIndex, int toIndex, byte val)
        {
            Arrays.fill(a, fromIndex, toIndex, val);
        }

        public static void fill(char[] a, char val)
        {
            Arrays.fill(a, val);
        }

        public static void fill(char[] a, int fromIndex, int toIndex, char val)
        {
            Arrays.fill(a, fromIndex, toIndex, val);
        }

        public static void fill(int[] a, int val)
        {
            Arrays.fill(a, val);
        }

        public static void fill(int[] a, int fromIndex, int toIndex, int val)
        {
            Arrays.fill(a, fromIndex, toIndex, val);
        }

        public static void fill(long[] a, long val)
        {
            Arrays.fill(a, val);
        }

        public static void fill(long[] a, int fromIndex, int toIndex, long val)
        {
            Arrays.fill(a, fromIndex, toIndex, val);
        }

        public static void fill(Object[] a, Object val)
        {
            Arrays.fill(a, val);
        }

        public static void fill(Object[] a, int fromIndex, int toIndex, Object val)
        {
            Arrays.fill(a, fromIndex, toIndex, val);
        }

        public static void fill(short[] a, short val)
        {
            Arrays.fill(a, val);
        }

        public static void fill(short[] a, int fromIndex, int toIndex, short val)
        {
            Arrays.fill(a, fromIndex, toIndex, val);
        }

        public static int hashCode(byte[] data)
        {
            if (data == null)
            {
                return 0;
            }

            int i = data.Length;
            int hc = i + 1;

            while (--i >= 0)
            {
                hc *= 257;
                hc ^= data[i];
            }

            return hc;
        }

        public static int hashCode(byte[] data, int off, int len)
        {
            if (data == null)
            {
                return 0;
            }

            int i = len;
            int hc = i + 1;

            while (--i >= 0)
            {
                hc *= 257;
                hc ^= data[off + i];
            }

            return hc;
        }

        public static int hashCode(char[] data)
        {
            if (data == null)
            {
                return 0;
            }

            int i = data.Length;
            int hc = i + 1;

            while (--i >= 0)
            {
                hc *= 257;
                hc ^= data[i];
            }

            return hc;
        }

        public static int hashCode(int[][] ints)
        {
            int hc = 0;

            for (int i = 0; i != ints.Length; i++)
            {
                hc = hc * 257 + hashCode(ints[i]);
            }

            return hc;
        }

        public static int hashCode(int[] data)
        {
            if (data == null)
            {
                return 0;
            }

            int i = data.Length;
            int hc = i + 1;

            while (--i >= 0)
            {
                hc *= 257;
                hc ^= data[i];
            }

            return hc;
        }

        public static int hashCode(int[] data, int off, int len)
        {
            if (data == null)
            {
                return 0;
            }

            int i = len;
            int hc = i + 1;

            while (--i >= 0)
            {
                hc *= 257;
                hc ^= data[off + i];
            }

            return hc;
        }

        public static int hashCode(long[] data)
        {
            if (data == null)
            {
                return 0;
            }

            int i = data.Length;
            int hc = i + 1;

            while (--i >= 0)
            {
                long di = data[i];
                hc *= 257;
                hc ^= (int)di;
                hc *= 257;
                hc ^= (int)((uint)di >> 32);
            }

            return hc;
        }

        public static int hashCode(long[] data, int off, int len)
        {
            if (data == null)
            {
                return 0;
            }

            int i = len;
            int hc = i + 1;

            while (--i >= 0)
            {
                long di = data[off + i];
                hc *= 257;
                hc ^= (int)di;
                hc *= 257;
                hc ^= (int)((uint)di >> 32);
            }

            return hc;
        }

        public static int hashCode(short[][][] shorts)
        {
            int hc = 0;

            for (int i = 0; i != shorts.Length; i++)
            {
                hc = hc * 257 + hashCode(shorts[i]);
            }

            return hc;
        }

        public static int hashCode(short[][] shorts)
        {
            int hc = 0;

            for (int i = 0; i != shorts.Length; i++)
            {
                hc = hc * 257 + hashCode(shorts[i]);
            }

            return hc;
        }

        public static int hashCode(short[] data)
        {
            if (data == null)
            {
                return 0;
            }

            int i = data.Length;
            int hc = i + 1;

            while (--i >= 0)
            {
                hc *= 257;
                hc ^= (data[i] & 0xff);
            }

            return hc;
        }

        public static int hashCode(Object[] data)
        {
            if (data == null)
            {
                return 0;
            }

            int i = data.Length;
            int hc = i + 1;

            while (--i >= 0)
            {
                hc *= 257;
                hc ^= data[i].GetHashCode();
            }
             

            return hc;
        }

        public static bool[] clone(bool[] data)
        {
            return (bool[])(data?.Clone());
        }

        public static byte[] clone(byte[] data)
        {
            return (byte[])(data?.Clone());
        }

        public static char[] clone(char[] data)
        {
            return (char[])(data?.Clone());
        }

        public static int[] clone(int[] data)
        {
            return (int[])(data?.Clone());
        }

        public static long[] clone(long[] data)
        {
            return (long[])(data?.Clone());
        }

        public static short[] clone(short[] data)
        {
            return (short[])(data?.Clone());
        }

      
        public static byte[] clone(byte[] data, byte[] existing)
        {
            if (data == null)
            {
                return null;
            }
            if ((existing == null) || (existing.Length != data.Length))
            {
                return clone(data);
            } 

            Array.Copy(data, 0, existing, 0, existing.Length);
            return existing;
        }

        public static long[] clone(long[] data, long[] existing)
        {
            if (data == null)
            {
                return null;
            }
            if ((existing == null) || (existing.Length != data.Length))
            {
                return clone(data);
            }
            Array.Copy(data, 0, existing, 0, existing.Length);
            return existing;
        }

        public static byte[][] clone(byte[][] data)
        {
            if (data == null)
            {
                return null;
            }

            byte[][] copy = new byte[data.Length][];

            for (int i = 0; i != copy.Length; i++)
            {
                copy[i] = clone(data[i]);
            }

            return copy;
        }

        public static byte[][][] clone(byte[][][] data)
        {
            if (data == null)
            {
                return null;
            }

            byte[][][] copy = new byte[data.Length][][];

            for (int i = 0; i != copy.Length; i++)
            {
                copy[i] = clone(data[i]);
            }

            return copy;
        }

        public static bool[] copyOf(bool[] original, int newLength)
        {
            bool[] copy = new bool[newLength];
            Array.Copy(original, 0, copy, 0, Math.Min(original.Length, newLength));
            return copy;
        }

        public static byte[] copyOf(byte[] original, int newLength)
        {
            byte[] copy = new byte[newLength];
            Array.Copy(original, 0, copy, 0, Math.Min(original.Length, newLength));
            return copy;
        }

        public static char[] copyOf(char[] original, int newLength)
        {
            char[] copy = new char[newLength];
            Array.Copy(original, 0, copy, 0, Math.Min(original.Length, newLength));
            return copy;
        }

        public static int[] copyOf(int[] original, int newLength)
        {
            int[] copy = new int[newLength];
            Array.Copy(original, 0, copy, 0, Math.Min(original.Length, newLength));
            return copy;
        }

        public static long[] copyOf(long[] original, int newLength)
        {
            long[] copy = new long[newLength];
            Array.Copy(original, 0, copy, 0, Math.Min(original.Length, newLength));
            return copy;
        }

        public static short[] copyOf(short[] original, int newLength)
        {
            short[] copy = new short[newLength];
            Array.Copy(original, 0, copy, 0, Math.Min(original.Length, newLength));
            return copy;
        }

   
        public static bool[] copyOfRange(bool[] original, int from, int to)
        {
            int newLength = getLength(from, to);
            bool[] copy = new bool[newLength];
            Array.Copy(original, from, copy, 0, Math.Min(original.Length - from, newLength));
            return copy;
        }

        /**
         * Make a copy of a range of bytes from the passed in array. The range can extend beyond the end
         * of the input array, in which case the returned array will be padded with zeroes.
         *
         * @param original
         *            the array from which the data is to be copied.
         * @param from
         *            the start index at which the copying should take place.
         * @param to
         *            the final index of the range (exclusive).
         *
         * @return a new byte array containing the range given.
         */
        public static byte[] copyOfRange(byte[] original, int from, int to)
        {
            int newLength = getLength(from, to);
            byte[] copy = new byte[newLength];
            Array.Copy(original, from, copy, 0, Math.Min(original.Length - from, newLength));
            return copy;
        }

        public static char[] copyOfRange(char[] original, int from, int to)
        {
            int newLength = getLength(from, to);
            char[] copy = new char[newLength];
            Array.Copy(original, from, copy, 0, Math.Min(original.Length - from, newLength));
            return copy;
        }

        public static int[] copyOfRange(int[] original, int from, int to)
        {
            int newLength = getLength(from, to);
            int[] copy = new int[newLength];
            Array.Copy(original, from, copy, 0, Math.Min(original.Length - from, newLength));
            return copy;
        }

        public static long[] copyOfRange(long[] original, int from, int to)
        {
            int newLength = getLength(from, to);
            long[] copy = new long[newLength];
            Array.Copy(original, from, copy, 0, Math.Min(original.Length - from, newLength));
            return copy;
        }

        public static short[] copyOfRange(short[] original, int from, int to)
        {
            int newLength = getLength(from, to);
            short[] copy = new short[newLength];
            Array.Copy(original, from, copy, 0, Math.Min(original.Length - from, newLength));
            return copy;
        }

   

        private static int getLength(int from, int to)
        {
            int newLength = to - from;
            if (newLength < 0)
            {
                return -1;
            }
            return newLength;
        }

        public static byte[] append(byte[] a, byte b)
        {
            if (a == null)
            {
                return new byte[] { b };
            }

            int length = a.Length;
            byte[] result = new byte[length + 1];
            Array.Copy(a, 0, result, 0, length);
            result[length] = b;
            return result;
        }

        public static short[] append(short[] a, short b)
        {
            if (a == null)
            {
                return new short[] { b };
            }

            int length = a.Length;
            short[] result = new short[length + 1];
            Array.Copy(a, 0, result, 0, length);
            result[length] = b;
            return result;
        }

        public static int[] append(int[] a, int b)
        {
            if (a == null)
            {
                return new int[] { b };
            }

            int length = a.Length;
            int[] result = new int[length + 1];
            Array.Copy(a, 0, result, 0, length);
            result[length] = b;
            return result;
        }

        public static String[] append(String[] a, String b)
        {
            if (a == null)
            {
                return new String[] { b };
            }

            int length = a.Length;
            String[] result = new String[length + 1];
            Array.Copy(a, 0, result, 0, length);
            result[length] = b;
            return result;
        }

        public static byte[] concatenate(byte[] a, byte[] b)
        {
            if (null == a)
            {
                // b might also be null
                return clone(b);
            }
            if (null == b)
            {
                // a might also be null
                return clone(a);
            }

            byte[] r = new byte[a.Length + b.Length];
            Array.Copy(a, 0, r, 0, a.Length);
            Array.Copy(b, 0, r, a.Length, b.Length);
            return r;
        }

        public static short[] concatenate(short[] a, short[] b)
        {
            if (null == a)
            {
                // b might also be null
                return clone(b);
            }
            if (null == b)
            {
                // a might also be null
                return clone(a);
            }

            short[] r = new short[a.Length + b.Length];
            Array.Copy(a, 0, r, 0, a.Length);
            Array.Copy(b, 0, r, a.Length, b.Length);
            return r;
        }

        public static byte[] concatenate(byte[] a, byte[] b, byte[] c)
        {
            if (null == a)
            {
                return concatenate(b, c);
            }
            if (null == b)
            {
                return concatenate(a, c);
            }
            if (null == c)
            {
                return concatenate(a, b);
            }

            byte[] r = new byte[a.Length + b.Length + c.Length];
            int pos = 0;
            Array.Copy(a, 0, r, pos, a.Length); pos += a.Length;
            Array.Copy(b, 0, r, pos, b.Length); pos += b.Length;
            Array.Copy(c, 0, r, pos, c.Length);
            return r;
        }

        public static byte[] concatenate(byte[] a, byte[] b, byte[] c, byte[] d)
        {
            if (null == a)
            {
                return concatenate(b, c, d);
            }
            if (null == b)
            {
                return concatenate(a, c, d);
            }
            if (null == c)
            {
                return concatenate(a, b, d);
            }
            if (null == d)
            {
                return concatenate(a, b, c);
            }

            byte[] r = new byte[a.Length + b.Length + c.Length + d.Length];
            int pos = 0;
            Array.Copy(a, 0, r, pos, a.Length); pos += a.Length;
            Array.Copy(b, 0, r, pos, b.Length); pos += b.Length;
            Array.Copy(c, 0, r, pos, c.Length); pos += c.Length;
            Array.Copy(d, 0, r, pos, d.Length);
            return r;
        }

        public static byte[] concatenate(byte[][] arrays)
        {
            int size = 0;
            for (int i = 0; i != arrays.Length; i++)
            {
                size += arrays[i].Length;
            }

            byte[] rv = new byte[size];

            int offSet = 0;
            for (int i = 0; i != arrays.Length; i++)
            {
                Array.Copy(arrays[i], 0, rv, offSet, arrays[i].Length);
                offSet += arrays[i].Length;
            }

            return rv;
        }

        public static int[] concatenate(int[] a, int[] b)
        {
            if (null == a)
            {
                // b might also be null
                return clone(b);
            }
            if (null == b)
            {
                // a might also be null
                return clone(a);
            }

            int[] r = new int[a.Length + b.Length];
            Array.Copy(a, 0, r, 0, a.Length);
            Array.Copy(b, 0, r, a.Length, b.Length);
            return r;
        }

        public static byte[] prepend(byte[] a, byte b)
        {
            if (a == null)
            {
                return new byte[] { b };
            }

            int length = a.Length;
            byte[] result = new byte[length + 1];
            Array.Copy(a, 0, result, 1, length);
            result[0] = b;
            return result;
        }

        public static short[] prepend(short[] a, short b)
        {
            if (a == null)
            {
                return new short[] { b };
            }

            int length = a.Length;
            short[] result = new short[length + 1];
            Array.Copy(a, 0, result, 1, length);
            result[0] = b;
            return result;
        }

        public static int[] prepend(int[] a, int b)
        {
            if (a == null)
            {
                return new int[] { b };
            }

            int length = a.Length;
            int[] result = new int[length + 1];
            Array.Copy(a, 0, result, 1, length);
            result[0] = b;
            return result;
        }

        public static byte[] reverse(byte[] a)
        {
            if (a == null)
            {
                return null;
            }

            int p1 = 0, p2 = a.Length;
            byte[] result = new byte[p2];

            while (--p2 >= 0)
            {
                result[p2] = a[p1++];
            }

            return result;
        }

        public static int[] reverse(int[] a)
        {
            if (a == null)
            {
                return null;
            }

            int p1 = 0, p2 = a.Length;
            int[] result = new int[p2];

            while (--p2 >= 0)
            {
                result[p2] = a[p1++];
            }

            return result;
        }

        public static byte[] reverseInPlace(byte[] a)
        {
            if (null == a)
            {
                return null;
            }

            int p1 = 0, p2 = a.Length - 1;
            while (p1 < p2)
            {
                byte t1 = a[p1], t2 = a[p2];
                a[p1++] = t2;
                a[p2--] = t1;
            }

            return a;
        }

        public static int[] reverseInPlace(int[] a)
        {
            if (null == a)
            {
                return null;
            }

            int p1 = 0, p2 = a.Length - 1;
            while (p1 < p2)
            {
                int t1 = a[p1], t2 = a[p2];
                a[p1++] = t2;
                a[p2--] = t1;
            }

            return a;
        }

      
    public static void clear(byte[] data)
    {
        if (null != data)
        {
            Arrays.fill(data, (byte)0x00);
        }
    }

    public static void clear(int[] data)
    {
        if (null != data)
        {
            Arrays.fill(data, 0);
        }
    }

    public static bool isNullOrContainsNull(Object[] array)
    {
        if (null == array)
        {
            return true;
        }
        int count = array.Length;
        for (int i = 0; i < count; ++i)
        {
            if (null == array[i])
            {
                return true;
            }
        }
        return false;
    }

    public static bool isNullOrEmpty(byte[] array)
    {
        return null == array || array.Length < 1;
    }

    public static bool isNullOrEmpty(int[] array)
    {
        return null == array || array.Length < 1;
    }

    public static bool isNullOrEmpty(Object[] array)
    {
        return null == array || array.Length < 1;
    }
}
}
