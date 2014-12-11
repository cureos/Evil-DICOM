using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvilDICOM.Core.Helpers
{
    public class ByteHelper
    {
        /// <summary>
        /// This method converts an array of bytes to a hexadecimal string
        /// </summary>
        /// <param name="Bytes">the array of bytes to be converted</param>
        /// <returns>a hexadecimal string representing the array of bytes passed in</returns>
        public static string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder();
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }

            return Result.ToString();
        }

        /// <summary>
        /// This method converts an array of bytes to a hexadecimal string
        /// </summary>
        /// <param name="Bytes">the array of bytes to be converted</param>
        /// <returns>a hexadecimal string representing the array of bytes passed in</returns>
        public static string ByteToHexString(byte b)
        {

            StringBuilder Result = new StringBuilder();
            string HexAlphabet = "0123456789ABCDEF";
            Result.Append(HexAlphabet[(int)(b >> 4)]);
            Result.Append(HexAlphabet[(int)(b & 0xF)]);
            return Result.ToString();
        }

        /// <summary>
        /// This method converts a hexadecimal string to an array of bytes.
        /// </summary>
        /// <param name="hexString">the hexadecimal string to be converted</param>
        /// <returns>an array of bytes representing the hexadecimal string passed in</returns>
        public static byte[] HexStringToByteArray(string hexString)
        {
            byte[] Bytes = new byte[hexString.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09,
                                 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0A, 0x0B, 0x0C, 0x0D,
                                 0x0E, 0x0F };

            for (int x = 0, i = 0; i < hexString.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(hexString[i + 0]) - '0'] << 4 |
                                  HexValue[Char.ToUpper(hexString[i + 1]) - '0']);
            }

            return Bytes;
        }

        public static string[] GetHexStringArray(byte[] bytes)
        {
            string[] hexArray = new string[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                hexArray[i] = ByteHelper.ByteArrayToHexString(new byte[] { bytes[i] });
            }
            return hexArray;
        }

        public static string StringToHexString(string str)
        {
            string hexOutput = "";
            char[] values = str.ToCharArray();
            foreach (char letter in values)
            {
                // Get the integral value of the character. 
                int value = Convert.ToInt32(letter);
                // Convert the decimal value to a hexadecimal value in string form. 
                string hex = String.Format("{0:X}", value);
                hexOutput += hex;

            }
            return hexOutput;
        }
        public static byte[] StringToByteArray(string str)
        {
           string _str =  ByteHelper.StringToHexString(str);
           byte[] _hexStr = ByteHelper.HexStringToByteArray(_str);
           return _hexStr;
        }

        public static bool AreEqual(byte[] bytes, byte[] toCompare)
        {
	        if (bytes == toCompare) return true;
            if (bytes == null || toCompare == null || bytes.Length != toCompare.Length)
                return false;
#if NET
			unsafe
			{
				fixed (byte* p1 = bytes, p2 = toCompare)
				{
					byte* x1 = p1, x2 = p2;
					int l = bytes.Length;
					for (int i = 0; i < l / 8; i++, x1 += 8, x2 += 8)
						if (*((long*)x1) != *((long*)x2)) return false;
					if ((l & 4) != 0) { if (*((int*)x1) != *((int*)x2)) return false; x1 += 4; x2 += 4; }
					if ((l & 2) != 0) { if (*((short*)x1) != *((short*)x2)) return false; x1 += 2; x2 += 2; }
					if ((l & 1) != 0) if (*((byte*)x1) != *((byte*)x2)) return false;
					return true;
				}
			}
#else
			for (var i = 0; i < bytes.Length; i++)
			{
				if (bytes[i] != toCompare[i]) return false;
			}
			return true;
#endif
		}

    }
}
