using System;
using System.Collections.Generic;
using System.Linq;
using EvilDICOM.Core.Dictionaries;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Reading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvilDICOM.Core.Tests
{
    [TestClass]
    public class TestExplicitBigEndian
    {
        /// <summary>
        /// Testing ReadAllElements with Null variable
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullReadAllElementsExplicitBigEndian()
        {
            List<IDICOMElement> elements;
            byte[] data = null;
            DICOMBinaryReader dr = new DICOMBinaryReader(data);
            elements = DICOMElementReader.ReadAllElements(dr, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN).ToList();
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullBinaryReaderReadBigEndian()
        {
            byte[] data = null;
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            TagReader.ReadBigEndian(dicomReader);
        }

        /// <summary>
        /// Test Null Tag Binary Reader for Explicit Big Endian
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void TestNullTagReaderBigEndian()
        {
            byte[] data = null;
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            var tag = TagReader.ReadBigEndian(dicomReader);
        }

        /// <summary>
        /// Test Tag Reader for Explicit Big Endian
        /// </summary>
        [TestMethod]
        public void TestTagReaderBigEndian()
        {
            byte[] data = ByteHelper.HexStringToByteArray("00100010");
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            var tag = TagReader.ReadBigEndian(dicomReader);
            Assert.AreEqual("0010", tag.Group.ToString());
            Assert.AreEqual("0010", tag.Element.ToString());
        }

        /// <summary>
        /// Test Null VR Reader Explicit Big Endian
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullVRReaderBigEndian()
        {
            byte[] data = null;
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            var vr = VRReader.Read(dicomReader);
        }

        /// <summary>
        /// Test VR Reader Explicit Big Endian
        /// </summary>
        [TestMethod]
        public void TestVRReaderBigEndian()
        {
            byte[] vrTypeBinary = ByteHelper.HexStringToByteArray("504E");
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(vrTypeBinary);
            var vr = VRReader.Read(dicomReader);
            Assert.AreEqual(VR.PersonName, vr);
        }

        /// <summary>
        /// Test Null Length Reader Explicit Big Endian
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullLengthReaderBigEndian()
        {
            byte[] data = null;
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);

            var vr = VRReader.Read(dicomReader);
            int length = LengthReader.ReadBigEndian(vr, dicomReader);
        }

        /// <summary>
        /// Test Null Data Reader Explicit Big Endian 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullDataReaderBigEndian()
        {
            byte[] data = null;
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);

            var vr = VRReader.Read(dicomReader);
            //int length = LengthReader.ReadBigEndian(vr, dicomReader);
            int length = 0;
            var dataReader = DataReader.ReadBigEndian(length, dicomReader);
        }

        /// <summary>
        /// Test Data Reader Explicit Big Endian
        /// </summary>
        [TestMethod]
        public void TestDataReaderBigEndian()
        {
            String data = "Smith^Jo";
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            DICOMBinaryReader dr = new DICOMBinaryReader(dataBytes);
            byte[] actualDataByte = DataReader.ReadBigEndian(data.Length, dr);
            String actualData = System.Text.Encoding.UTF8.GetString(actualDataByte);
            Assert.AreEqual(data, actualData);
        }

        /// <summary>
        /// Tests the GenerateElement method with valid values
        /// </summary>
        [TestMethod]
        public void TestGenerateElement()
        {
            byte[] data = ByteHelper.HexStringToByteArray("536D6974685E4A6F6520"); //Smith^Joe
            Tag t = new Tag("0010","0010");
            var element= ElementFactory.GenerateElement(t, VR.PersonName, data, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
            
            //Asserts
            Assert.AreEqual("0010", element.Tag.Group);
            Assert.AreEqual("0010", element.Tag.Element);
            Assert.AreEqual("PatientName", TagDictionary.GetDescription(element.Tag));
            Assert.AreEqual(VR.PersonName, TagDictionary.GetVRFromTag(element.Tag));
            Assert.AreEqual("Smith^Joe", element.DData as String);
        }

        /// <summary>
        /// Tests that the SkipItemBigEndian method changes the StreamPosition of a DicomReader correctly
        /// </summary>
        [TestMethod]
        public void TestSkipItemBigEndian()
        {
            byte[] data = CreateDataByteArray("00200020");

            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            SequenceItemReader.SkipItemBigEndian(dicomReader);
            
            //Asserts
            Assert.AreEqual(8, dicomReader.StreamPosition);
        }

        [TestMethod]
        public void TestReadItems()
        {               
            byte[] data = CreateDataByteArray("00200020");
            var dicomObjects = SequenceReader.ReadItems(data, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
        }

        /// <summary>
        /// Test the Sequence Item Reader for Null DICOM Binary Reader
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullSequenceImageReadBigEndian()
        {
            byte[] data = null;
            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            var dicomObject = SequenceItemReader.ReadBigEndian(dicomReader, TransferSyntax.EXPLICIT_VR_BIG_ENDIAN);
        }

        /// <summary>
        /// Test Null Indefinite Length Explicit Big Endian
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReadIndefiniteLengthBigEndian001()
        {            
            //Initialize the data element byte array. This byte array uses Explicit Big Endian
            byte[] data = null;

            DICOMBinaryReader dicomReader = new DICOMBinaryReader(data);
            var dicomObject = SequenceReader.ReadIndefiniteLengthBigEndian(dicomReader);
        }

        /// <summary>
        /// Testing the ReadIndefiniteLengthBigEndian with a null value
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReadIndefiniteLengthBigEndian002()
        {
            int i = SequenceReader.ReadIndefiniteLengthBigEndian(null);
        }

        // Bug
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullBinaryArrayReadBigEndian()
        {
            byte[] data = null;
            TagReader.ReadBigEndian(data);
        }

        // Bug
        [TestMethod]
        public void TestLengthReaderBigEndian()
        {
            int expectedLength = 8;
            byte[] data = BitConverter.GetBytes(expectedLength);
            DICOMBinaryReader dr = new DICOMBinaryReader(data);
            int length = LengthReader.ReadBigEndian(VR.Null, dr);
            Assert.AreEqual(length, expectedLength);
        }

        #region Private Methods

        /// <summary>
        /// Creates the data byte array with patient information
        /// </summary>
        /// <returns>byte array</returns>
        private static byte[] CreateDataByteArray(string hexString)
        {
            byte[] tagBytes = ByteHelper.HexStringToByteArray(hexString); //Patient Orientation
            String vrType = "504E";
            String vrLength = "0A00";
            String vrValue = "536D6974685E4A6F6520";// Smith^Joe

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

            return data;
        }

        #endregion Private Methods
    }
}
