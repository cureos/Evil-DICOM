using EvilDICOM.Core.Helpers;

namespace EvilDICOM.Core.IO.Writing
{
    public class DICOMFileWriter
    {
#if PORTABLE
        public static void WriteLittleEndian(System.IO.Stream filePath, DICOMWriteSettings settings, DICOMObject toWrite)
#else
        public static void WriteLittleEndian(string filePath, DICOMWriteSettings settings, DICOMObject toWrite)
#endif
        {
            using (DICOMBinaryWriter dw = new DICOMBinaryWriter(filePath))
            {
                DICOMPreambleWriter.Write(dw);
                TransferSyntaxHelper.SetSyntax(toWrite, settings.TransferSyntax);
                DICOMObjectWriter.WriteObjectLittleEndian(dw, settings, toWrite);
            }
        }

#if PORTABLE
        public static void WriteLittleEndian(System.IO.Stream filePath, DICOMObject toWrite)
#else
        public static void WriteLittleEndian(string filePath, DICOMObject toWrite)
#endif
        {
            WriteLittleEndian(filePath, DICOMWriteSettings.Default(), toWrite);
        }
    }
}
