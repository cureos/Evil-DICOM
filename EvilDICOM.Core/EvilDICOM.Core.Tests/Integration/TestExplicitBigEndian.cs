using System;
using EvilDICOM.Core.Dictionaries;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.IO.Reading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvilDICOM.Core.Tests.Integration
{

    [TestClass]
    public class TestExplicitBigEndian
    {

        [TestMethod]
        public void TestExplicitBigEndianBinaryReader()
        {
            // Explicit Encoding
            // 1) Tag
            //      1. Group Number
            //      2. Element Number
            // 2) VR Type
            // 3) VR Length
            // 4) VR Value

            // Patient Name in Bytes, Tag and Length
            String tag = "00100010";
            String vrType = "504E";
            String vrLength = "0A00";
            String vrValue = "536D6974685E4A6F6520";     // Smith^Joe

            // Get Binary Code from Hex
            byte[] tagBinary = ByteHelper.HexStringToByteArray(tag);
            byte[] vrTypeBinary = ByteHelper.HexStringToByteArray(vrType);
            byte[] vrLengthBinary = ByteHelper.HexStringToByteArray(vrLength);
            byte[] vrValueBinary = ByteHelper.HexStringToByteArray(vrValue);

            //Initialize the data element byte array. This byte array uses Explicit Big Endian
            byte[] data = new byte[tagBinary.Length + vrTypeBinary.Length + vrLengthBinary.Length + vrValueBinary.Length];

            // Combine all the binary together into binary data
            System.Buffer.BlockCopy(tagBinary, 0, data, 0, tagBinary.Length);
            System.Buffer.BlockCopy(vrTypeBinary, 0, data, tagBinary.Length, vrTypeBinary.Length);
            System.Buffer.BlockCopy(vrLengthBinary, 0, data, tagBinary.Length + vrTypeBinary.Length, vrLengthBinary.Length);
            System.Buffer.BlockCopy(vrValueBinary, 0, data, tagBinary.Length + vrTypeBinary.Length + vrLengthBinary.Length, vrValueBinary.Length);

            // Create DICOM Object
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            var dicomObj = DICOMObjectReader.ReadObject(dicomReader, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
            var numElem = dicomObj.AllElements.Count;

            Assert.AreEqual(numElem, 1);

            foreach (var elem in dicomObj.AllElements)
            {
                Assert.AreEqual("0010", elem.Tag.Group.ToString());
                Assert.AreEqual("0010", elem.Tag.Element.ToString());
                Assert.AreEqual("PatientName", TagDictionary.GetDescription(elem.Tag));
                Assert.AreEqual(VR.PersonName, TagDictionary.GetVRFromTag(elem.Tag));
                Assert.AreEqual("Smith^Joe", elem.DData as String);
            }
        }

        /// <summary>
        /// Tests to make sure that reversing to Little Endian fails when the transfer syntax is EXPLICIT_VR_BIG_ENDIAN
        /// </summary>
        [TestMethod]
        public void TestExplicitBigEndianBinaryReader002()
        {
            // Patient Name in Bytes, Tag and Length
            byte[] tagBytes = ByteHelper.HexStringToByteArray("00200020"); //Patient Orientation
            String vrType = "504E";
            String vrLength = "0A00";
            String vrValue = "536D6974685E4A6F6520";// Smith^Joe

            //Reverse to Little Endian
            Array.Reverse(tagBytes);

            // Get Binary Code from Hex            
            byte[] vrTypeBinary = ByteHelper.HexStringToByteArray(vrType);
            byte[] vrLengthBinary = ByteHelper.HexStringToByteArray(vrLength);
            byte[] vrValueBinary = ByteHelper.HexStringToByteArray(vrValue);

            //Initialize the data element byte array. This byte array uses Explicit Big Endian
            byte[] data = new byte[tagBytes.Length + vrTypeBinary.Length + vrLengthBinary.Length + vrValueBinary.Length];

            // Combine all the binary together into binary data
            System.Buffer.BlockCopy(tagBytes, 0, data, 0, tagBytes.Length);
            System.Buffer.BlockCopy(vrTypeBinary, 0, data, tagBytes.Length, vrTypeBinary.Length);
            System.Buffer.BlockCopy(vrLengthBinary, 0, data, tagBytes.Length + vrTypeBinary.Length, vrLengthBinary.Length);
            System.Buffer.BlockCopy(vrValueBinary, 0, data, tagBytes.Length + vrTypeBinary.Length + vrLengthBinary.Length, vrValueBinary.Length);

            // Create DICOM Object
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            var dicomObj = DICOMObjectReader.ReadObject(dicomReader, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
            var numElem = dicomObj.AllElements.Count;

            Assert.AreEqual(numElem, 1);

            //When the byte array is reversed (put in little endian), the tag and VR is unknown when the Transfer Systax is still Big Endian.
            foreach (var elem in dicomObj.AllElements)
            {
                Assert.AreNotEqual("0020", elem.Tag.Group.ToString());
                Assert.AreNotEqual("0020", elem.Tag.Element.ToString());
                Assert.AreEqual("Unknown Tag", TagDictionary.GetDescription(elem.Tag));
                Assert.AreEqual(VR.Unknown, TagDictionary.GetVRFromTag(elem.Tag));
                Assert.AreEqual("Smith^Joe", elem.DData as String);
            }    
        }

        [TestMethod]
        public void TestExplicitBigEndianBinaryReaderWithArray()
        {
            // Explicit Encoding
            // 1) Tag
            //      1. Group Number
            //      2. Element Number
            // 2) VR Type
            // 3) VR Length
            // 4) VR Value

            // Patient Name in Bytes, Tag and Length
            String tag = "00100010";
            String vrType = "504E";
            String vrLength = "0A00";
            String vrValue = "536D6974685E4A6F6520";     // Smith^Joe

            // Get Binary Code from Hex
            byte[] tagBinary = ByteHelper.HexStringToByteArray(tag);
            byte[] vrTypeBinary = ByteHelper.HexStringToByteArray(vrType);
            byte[] vrLengthBinary = ByteHelper.HexStringToByteArray(vrLength);
            byte[] vrValueBinary = ByteHelper.HexStringToByteArray(vrValue);

            //Initialize the data element byte array. This byte array uses Explicit Big Endian
            byte[] data = new byte[tagBinary.Length + vrTypeBinary.Length + vrLengthBinary.Length + vrValueBinary.Length];

            // Combine all the binary together into binary data
            System.Buffer.BlockCopy(tagBinary, 0, data, 0, tagBinary.Length);
            System.Buffer.BlockCopy(vrTypeBinary, 0, data, tagBinary.Length, vrTypeBinary.Length);
            System.Buffer.BlockCopy(vrLengthBinary, 0, data, tagBinary.Length + vrTypeBinary.Length, vrLengthBinary.Length);
            System.Buffer.BlockCopy(vrValueBinary, 0, data, tagBinary.Length + vrTypeBinary.Length + vrLengthBinary.Length, vrValueBinary.Length);

            // Create DICOM Object
            var dicomObj = DICOMObjectReader.ReadObject(data, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
            var numElem = dicomObj.AllElements.Count;

            Assert.AreEqual(numElem, 1);

            foreach (var elem in dicomObj.AllElements)
            {
                Assert.AreEqual("0010", elem.Tag.Group.ToString());
                Assert.AreEqual("0010", elem.Tag.Element.ToString());
                Assert.AreEqual("PatientName", TagDictionary.GetDescription(elem.Tag));
                Assert.AreEqual(VR.PersonName, TagDictionary.GetVRFromTag(elem.Tag));
                Assert.AreEqual("Smith^Joe", elem.DData as String);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReadDicomBigExplicitBinaryReaderWithNull()
        {
            DICOMBinaryReader dr = null;
            var dicomObj = DICOMObjectReader.ReadObject(dr, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReadDicomBigExplicitBinaryReaderWithNullArray()
        {
            byte[] data = null;
            var dicomObj = DICOMObjectReader.ReadObject(data, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
        }
    }
}
