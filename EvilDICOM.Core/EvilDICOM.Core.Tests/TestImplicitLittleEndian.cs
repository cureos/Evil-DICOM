using System;
using EvilDICOM.Core.Dictionaries;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Reading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//Unit Test

namespace EvilDICOM.Core.Tests
{
    [TestClass]
    public class TestImplicitLittleEndian
    {
        /// <summary>
        /// Read tag using binaryReader
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_001()
        {
            //correspond to the tag (0010, 1040)
            byte[] tagBytes = ByteHelper.HexStringToByteArray("10400010");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "1040";
            String expectedTagDescription = "PatientAddress";

            //Get a tag object out of the tagBytes
            DICOMBinaryReader dr = new DICOMBinaryReader(tagBytes);
            var tag = TagReader.ReadLittleEndian(dr);

            //Assert section 
            Assert.AreEqual(expectedGroup, tag.Group.ToString());
            Assert.AreEqual(expectedElement,tag.Element.ToString());
            Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(tag));
        }

        /// <summary>
        /// Read tag that has a length value bigger than expected with a binaryReader
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_002()
        {
            //correspond to the tag (0010, 1040)
            byte[] tagBytes = ByteHelper.HexStringToByteArray("1040000100");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "1040";
            String expectedTagDescription = "PatientAddress";

            //Get a tag object out of the tagBytes
            DICOMBinaryReader dr = new DICOMBinaryReader(tagBytes);
            var tag = TagReader.ReadLittleEndian(dr);

            //Assert section 
            Assert.AreEqual(expectedGroup, tag.Group.ToString());
            Assert.AreEqual(expectedElement, tag.Element.ToString());
            Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(tag));
        }

        /// <summary>
        /// Read tag using a byte array
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_003()
        {
            //correspond to the tag (0010, 1040)
            byte[] tagBytes = ByteHelper.HexStringToByteArray("10400010");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "1040";
            String expectedTagDescription = "PatientAddress";

            //Get a tag out of the tagBytes
            var tag = TagReader.ReadLittleEndian(tagBytes);

            //Assert section 
            Assert.AreEqual(expectedGroup, tag.Group.ToString());
            Assert.AreEqual(expectedElement, tag.Element.ToString());
            Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(tag));
        }

        /// <summary>
        /// Read tag that has an invalid length with a byte array
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_004()
        {
            //correspond to the tag (0010, 1040)
            byte[] tagBytes = ByteHelper.HexStringToByteArray("1040000100");

            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);

            //expected value to validate the test
            String expectedGroup = "0010";
            String expectedElement = "1040";
            String expectedTagDescription = "PatientAddress";

            //Get a tag out of the tagBytes
            var tag = TagReader.ReadLittleEndian(tagBytes);

            //Assert section 
            Assert.AreEqual(expectedGroup, tag.Group.ToString());
            Assert.AreEqual(expectedElement, tag.Element.ToString());
            Assert.AreEqual(expectedTagDescription, TagDictionary.GetDescription(tag));
        }

        /// <summary>
        /// Read the length of a tag using the implicit method
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_005()
        {
            //input data for the test
            int expectedLength = 10;
            byte[] lengthBytes = BitConverter.GetBytes(expectedLength);

            //Get data length
            DICOMBinaryReader dr = new DICOMBinaryReader(lengthBytes);
            int actualLength = LengthReader.ReadLittleEndian(VR.Null, dr);

            //Assert section 
            Assert.AreEqual(expectedLength, actualLength);
        }

        /// <summary>
        /// Read the length of a tag using the explicit method
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_006()
        {
            //input data for the test
            int expectedLength = 10;
            byte[] lengthBytes = BitConverter.GetBytes(expectedLength);

            //Get data length
            DICOMBinaryReader dr = new DICOMBinaryReader(lengthBytes);
            int actualLength = LengthReader.ReadLittleEndian(dr,4);

            //Assert section 
            Assert.AreEqual(expectedLength, actualLength);
        }

        /// <summary>
        /// Read the data of a tag
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_007()
        {
            //input data for the test
            String data = "Smith^Jo";

            //bytes representation of the data 
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);

            //Get dicom data
            DICOMBinaryReader dr = new DICOMBinaryReader(dataBytes);
            byte [] actualDataByte = DataReader.ReadLittleEndian(data.Length, dr, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);
            String actualData = System.Text.Encoding.UTF8.GetString(actualDataByte);

            //Assert section 
            Assert.AreEqual(data, actualData);
        }

        /// <summary>
        /// Create a data element using the factory
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_008()
        {
            //input data for the test
            String data = "Smith^Jo";
            Tag tag = new Tag("0010", "2297");
            VR valueRepresentation = VR.PersonName;

            //bytes representation of the data 
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);

            //Get dicom data element
            DICOMBinaryReader dr = new DICOMBinaryReader(dataBytes);
            byte[] actualDataByte = DataReader.ReadLittleEndian(data.Length, dr, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);
            IDICOMElement dataElement = ElementFactory.GenerateElement(tag, valueRepresentation, actualDataByte, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);


            //Assert section 
            Assert.AreEqual(tag.ToString(), dataElement.Tag.ToString());
            Assert.AreEqual(valueRepresentation, TagDictionary.GetVRFromTag(dataElement.Tag));
            Assert.AreEqual(data, dataElement.DData as String);
        }

        /// <summary>
        /// Create a data element with an invalid tag
        /// </summary>
        [TestMethod]
        public void TestImplicitLittleEndian_009()
        {
            //input data for the test
            String data = "Smith^Jo";
            Tag tag = new Tag("00100", "22970");
            VR valueRepresentation = VR.PersonName;

            //bytes representation of the data 
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);

            //Get dicom data element
            DICOMBinaryReader dr = new DICOMBinaryReader(dataBytes);
            byte[] actualDataByte = DataReader.ReadLittleEndian(data.Length, dr, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);
            IDICOMElement dataElement = ElementFactory.GenerateElement(tag, valueRepresentation, actualDataByte, TransferSyntax.IMPLICIT_VR_LITTLE_ENDIAN);


            //Assert section 
            Assert.AreEqual(tag.ToString(), dataElement.Tag.ToString());
            Assert.AreEqual(valueRepresentation, TagDictionary.GetVRFromTag(dataElement.Tag));
            Assert.AreEqual(data, dataElement.DData as String);
        }
    }
}
