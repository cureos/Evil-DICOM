using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvilDICOM.Core.IO.Data
{
    public class DICOMString
    {
        public static string Read(byte[] data)
        {
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            return enc.GetString(data, 0, data.Length).TrimEnd(new char[] { '\0' }).TrimEnd(new char[] { ' ' });
        }

        public static byte[] Write(string data)
        {
            System.Text.UTF8Encoding ascii = new System.Text.UTF8Encoding();

            if (IsEven(data))
            {
                return ascii.GetBytes(data);
            }
            else
            {
                return PadOddBytes(ascii, data);
            }           
        }

        private static bool IsEven(string data)
        {
            return data.Length % 2 == 0;
        }

        private static byte[] PadOddBytes(UTF8Encoding ascii, string data)
        {
            return ascii.GetBytes(data + '\0');
        }

      
    }
}
