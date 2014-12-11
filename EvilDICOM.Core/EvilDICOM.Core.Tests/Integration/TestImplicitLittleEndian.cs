using System;
using EvilDICOM.Core.Dictionaries;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.IO.Reading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//Integration Test

namespace EvilDICOM.Core.Tests.Integration
{
    [TestClass]
    public class TestImplicitLittleEndian
    {
        /// <summary>
        /// Read a byte stream using the binaryReader
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_001()
        {
            //input data for the test
            String data = "Smith^Jo";

            //correspond to the tag (0010, 1005). Length is 4 bytes as expected
            byte[] tagBytes = ByteHelper.HexStringToByteArray("10050010");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "1005";
            String expectedTagDescription = "PatientBirthName";
            VR expectedValueRepresentation = VR.PersonName;

            //bytes representation of the data and its length
            //the data don't need to be converted because it is a text value
            // dataLengthBytes is already in little Endian and its length is 4 bytes
            //as expected since GetBytes returns a 32-bit array of bytes
            byte [] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] dataLengthBytes = BitConverter.GetBytes(data.Length);

            //Initialize the data element byte array. This byte array uses implicit little endian
            byte[] dataElement = new byte[tagBytes.Length + dataLengthBytes.Length + dataBytes.Length];

            //Copy tag, length of data and data in dataElement
            System.Buffer.BlockCopy(tagBytes,0,dataElement,0,tagBytes.Length);
            System.Buffer.BlockCopy(dataLengthBytes,0,dataElement,tagBytes.Length,dataLengthBytes.Length);
            System.Buffer.BlockCopy(dataBytes,0,dataElement,tagBytes.Length + dataLengthBytes.Length,dataBytes.Length);

            //Get an DICOM object out of the dataElement
            DICOMBinaryReader dr = new DICOMBinaryReader(dataElement);
            var dicomObj = DICOMObjectReader.ReadObject(dr, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);
            var numElem = dicomObj.AllElements.Count;

            //Assert section 
            Assert.AreEqual(1, numElem);

            foreach(var elem in dicomObj.AllElements)
            {
                Assert.AreEqual(expectedGroup, elem.Tag.Group.ToString());
                Assert.AreEqual(expectedElement, elem.Tag.Element.ToString());
                Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(elem.Tag));
                Assert.AreEqual(expectedValueRepresentation, TagDictionary.GetVRFromTag(elem.Tag));
                String a = elem.DData as String;
                Assert.AreEqual(data, elem.DData as String);
            }            
        }

        
        /// <summary>
        /// Read byte stream that has an invalid tag length with a binaryReader
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_002()
        {
            //input data for the test
            String data = "Smith^Jo";

            //correspond to the tag (0010, 1005). 
            //Length here is invalid, as it should be 4 bytes for both the Group and Element
            byte[] tagBytes = ByteHelper.HexStringToByteArray("1005000100");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "1005";
            String expectedTagDescription = "PatientBirthName";
            VR expectedValueRepresentation = VR.PersonName;

            //bytes representation of the data and its length
            //the data don't need to be converted because it is a text value
            // dataLengthBytes is already in little Endian and its length is 4 bytes
            //as expected since GetBytes returns a 32-bit array of bytes
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] dataLengthBytes = BitConverter.GetBytes(data.Length);

            //Initialize the data element byte array. This byte array uses implicit little endian
            byte[] dataElement = new byte[tagBytes.Length + dataLengthBytes.Length + dataBytes.Length];

            //Copy tag, length of data and data in dataElement
            System.Buffer.BlockCopy(tagBytes, 0, dataElement, 0, tagBytes.Length);
            System.Buffer.BlockCopy(dataLengthBytes, 0, dataElement, tagBytes.Length, dataLengthBytes.Length);
            System.Buffer.BlockCopy(dataBytes, 0, dataElement, tagBytes.Length + dataLengthBytes.Length, dataBytes.Length);

            //Get an DICOM object out of the dataElement
            DICOMBinaryReader dr = new DICOMBinaryReader(dataElement);
            var dicomObj = DICOMObjectReader.ReadObject(dr, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);
            var numElem = dicomObj.AllElements.Count;

            //Assert section 
            Assert.AreEqual(1, numElem);

            foreach (var elem in dicomObj.AllElements)
            {
                Assert.AreEqual(expectedGroup, elem.Tag.Group.ToString());
                Assert.AreEqual(expectedElement, elem.Tag.Element.ToString());
                Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(elem.Tag));
                Assert.AreEqual(expectedValueRepresentation, TagDictionary.GetVRFromTag(elem.Tag));
                String a = elem.DData as String;
                Assert.AreEqual(data, elem.DData as String);
            }
        }

        /// <summary>
        /// Read a byte stream by passing a byte array
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_003()
        {
            //input data for the test
            String data = "Smith^Jo";

            //correspond to the tag (0010, 0010)
            byte[] tagBytes = ByteHelper.HexStringToByteArray("00100010");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "0010";
            String expectedTagDescription = "PatientName";
            VR expectedValueRepresentation = VR.PersonName;

            //bytes representation of the data and its length
            //the data don't need to be converted because it is a text value
            // dataLengthBytes is already in little Endian
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] dataLengthBytes = BitConverter.GetBytes(data.Length);

            //Initialize the data element byte array. This byte array uses implicit little endian
            byte[] dataElement = new byte[tagBytes.Length + dataLengthBytes.Length + dataBytes.Length];

            //Copy tag, length of data and data in dataElement
            System.Buffer.BlockCopy(tagBytes, 0, dataElement, 0, tagBytes.Length);
            System.Buffer.BlockCopy(dataLengthBytes, 0, dataElement, tagBytes.Length, dataLengthBytes.Length);
            System.Buffer.BlockCopy(dataBytes, 0, dataElement, tagBytes.Length + dataLengthBytes.Length, dataBytes.Length);

            //Get an DICOM object out of the dataElement
            //DICOMBinaryReader dr = new DICOMBinaryReader(dataElement);
            var dicomObj = DICOMObjectReader.ReadObject(dataElement, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);
            var numElem = dicomObj.AllElements.Count;

            //Assert section 
            Assert.AreEqual(1, numElem);

            foreach (var elem in dicomObj.AllElements)
            {
                Assert.AreEqual(expectedGroup, elem.Tag.Group.ToString());
                Assert.AreEqual(expectedElement, elem.Tag.Element.ToString());
                Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(elem.Tag));
                Assert.AreEqual(expectedValueRepresentation, TagDictionary.GetVRFromTag(elem.Tag));
                String a = elem.DData as String;
                Assert.AreEqual(data, elem.DData as String);
            }
        }

        /// <summary>
        /// Read a byte stream that has an invalid length value in it
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_004()
        {
            //input data for the test
            String data = "Smith^Jo";

            //correspond to the tag (0010, 0010)
            byte[] tagBytes = ByteHelper.HexStringToByteArray("0010000100");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "0010";
            String expectedTagDescription = "PatientName";
            VR expectedValueRepresentation = VR.PersonName;

            //bytes representation of the data and its length
            //the data don't need to be converted because it is a text value
            // dataLengthBytes is already in little Endian
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            byte[] dataLengthBytes = BitConverter.GetBytes(data.Length);

            //Initialize the data element byte array. This byte array uses implicit little endian
            byte[] dataElement = new byte[tagBytes.Length + dataLengthBytes.Length + dataBytes.Length];

            //Copy tag, length of data and data in dataElement
            System.Buffer.BlockCopy(tagBytes, 0, dataElement, 0, tagBytes.Length);
            System.Buffer.BlockCopy(dataLengthBytes, 0, dataElement, tagBytes.Length, dataLengthBytes.Length);
            System.Buffer.BlockCopy(dataBytes, 0, dataElement, tagBytes.Length + dataLengthBytes.Length, dataBytes.Length);

            //Get an DICOM object out of the dataElement
            //DICOMBinaryReader dr = new DICOMBinaryReader(dataElement);
            var dicomObj = DICOMObjectReader.ReadObject(dataElement, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);
            var numElem = dicomObj.AllElements.Count;

            //Assert section 
            Assert.AreEqual(1, numElem);

            foreach (var elem in dicomObj.AllElements)
            {
                Assert.AreEqual(expectedGroup, elem.Tag.Group.ToString());
                Assert.AreEqual(expectedElement, elem.Tag.Element.ToString());
                Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(elem.Tag));
                Assert.AreEqual(expectedValueRepresentation, TagDictionary.GetVRFromTag(elem.Tag));
                String a = elem.DData as String;
                Assert.AreEqual(data, elem.DData as String);
            }
        }

        /// <summary>
        /// Read a byte stream with a binaryReader set to null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestImplicitLittleEndian_005()
        {
            DICOMBinaryReader dr = null;
            var dicomObj = DICOMObjectReader.ReadObject(dr, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);

        }

        /// <summary>
        /// Read a byte stream with a byte array set to null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestImplicitLittleEndian_006()
        {
            byte[] dataElement = null;
            var dicomObj = DICOMObjectReader.ReadObject(dataElement, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);

        }
    }
}
