using System.Text;

namespace EvilDICOM.Core.IO.Data
{
    public class DICOMString
    {
        public static string Read(byte[] data)
        {
            var enc = new UTF8Encoding();
            return enc.GetString(data, 0, data.Length).TrimEnd(new[] { '\0' }).TrimEnd(new[] { ' ' });
        }

        public static byte[] Write(string data)
        {
            var ascii = new UTF8Encoding();

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

        private static byte[] PadOddBytes(Encoding ascii, string data)
        {
            return ascii.GetBytes(data + '\0');
        }

      
    }
}
