using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.Enums;

namespace EvilDICOM.Core.IO.Reading
{
    public class DICOMObjectReader
    {
        public static DICOMObject ReadObject(DICOMBinaryReader dr, TransferSyntax syntax)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("DICOMBinaryReader cannot be null");
            }
            List<IDICOMElement> elements = DICOMElementReader.ReadAllElements(dr, syntax);
            return new DICOMObject(elements);
        }

        public static DICOMObject ReadObject(byte[] objectBytes, TransferSyntax syntax)
        {
            if (objectBytes == null)
            {
                throw new ArgumentNullException("objectBytes cannot be null");
            }

            List<IDICOMElement> elements;
            using (DICOMBinaryReader dr = new DICOMBinaryReader(objectBytes))
            {
                elements = DICOMElementReader.ReadAllElements(dr, syntax);
            }
            return new DICOMObject(elements);
        }
    }
}
