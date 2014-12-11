using System;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.IO.Reading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvilDICOM.Core.Tests
{
    [TestClass]
    public class TestExplicitLittleEndian
    {
        [TestInitialize]
        public void Initialize()
        {

        }
        // DICOM Length shuuld be even
        [TestMethod]
        public void TestDICOMDataLengthExplicitLittleEndianOdd()
        {   
           // input test
            int oddDataLength = 7;
           // expected values
            int expectedDataLength = oddDataLength + 1;
            byte[] dataLengthBytes = BitConverter.GetBytes(oddDataLength); // 4 bytes
            DICOMBinaryReader dr = new DICOMBinaryReader(dataLengthBytes);
           int actualdataLength =   LengthReader.ReadLittleEndian(VR.PersonName, dr);
           Assert.AreEqual(expectedDataLength, actualdataLength);
        }

        [TestMethod]
        public void TestDICOMDataLengthExplicitLittleEndianEven()
        {
            // input test
            int oddDataLength = 8;
            // expected values
            int expectedDataLength = oddDataLength;
            byte[] dataLengthBytes = BitConverter.GetBytes(oddDataLength); // 4 bytes
            DICOMBinaryReader dr = new DICOMBinaryReader(dataLengthBytes);
            int actualdataLength = LengthReader.ReadLittleEndian(VR.PersonName, dr);
            Assert.AreEqual(expectedDataLength, actualdataLength);
        }

        [TestMethod]
        public void TestValueRepresentationExplicitLittleEndian()
        {
            // input test
            string valueRepresentation = "OB";
            // expected values
            VR expectedvalueRepresentation = VR.OtherByteString;
            byte[] vrBytes = ByteHelper.StringToByteArray(valueRepresentation);
            DICOMBinaryReader dr = new DICOMBinaryReader(vrBytes);
            VR actualValueRepresentation = VRReader.Read(dr);
            Assert.AreEqual(expectedvalueRepresentation, actualValueRepresentation);
        }

    }
}
