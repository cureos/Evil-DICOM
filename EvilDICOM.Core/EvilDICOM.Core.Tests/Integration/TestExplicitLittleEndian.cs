using System;
using System.IO;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.IO.Reading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvilDICOM.Core.Tests.Integration
{
    [TestClass]
    public class TestExplicitLittleEndian
    {

        [TestInitialize]
        public void Initialize()
        {

        }
        [TestMethod]
        public void TestEncodingExplicitLittleEndianWithBinaryReader()
        {

          BinaryReader readBinary;
            //input data for the test
          string tag = "00100010";
            //[one family names; one given name; no middle name; no prefix; no suffixes.] 
            String data = "Smith^Jo";
            string vrString = "PN";
            //expected value to validate the test
            byte[] expectedGroup = new byte[2];
            expectedGroup[0] = 16;
            expectedGroup[1] = 0;
            byte[] expectedElement = new byte[2];
            expectedElement[0] = 16;
            expectedElement[1] = 0;
           // String expectedTagDescription = "PatientName";
            byte[] expectedValueRepresentation =  new byte[2];
            expectedValueRepresentation[0] = 80;
            expectedValueRepresentation[1] = 78;
            byte[] expectedDataLength = new byte[2];
            expectedDataLength[0] = 8;
            expectedDataLength[1] = 0;

            // Encoding process
            byte[] tagBytes = ByteHelper.HexStringToByteArray(tag);
            //Reverse byte array to use little endian encoding
            Array.Reverse(tagBytes);
            byte[] vrBytes = ByteHelper.StringToByteArray(vrString);
            //bytes representation of the data and its length
            //the data don't need to be converted because it is a text value
            byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(data);
            // dataLengthBytes is already in little Endian
            // make sure GetBytes use unit16- bit 
            byte[] dataLengthBytes = BitConverter.GetBytes((short)data.Length);

            //Initialize the data element byte array. This byte array uses explicit little endian
            byte[] dataElement = new byte[tagBytes.Length + vrBytes.Length +dataLengthBytes.Length + dataBytes.Length];
            
            //Copy tag, length of data and data in dataElement
            System.Buffer.BlockCopy(tagBytes, 0, dataElement, 0, tagBytes.Length);
            System.Buffer.BlockCopy(vrBytes, 0, dataElement, tagBytes.Length, vrBytes.Length);
            System.Buffer.BlockCopy(dataLengthBytes, 0, dataElement, tagBytes.Length + vrBytes.Length, dataLengthBytes.Length);
            System.Buffer.BlockCopy(dataBytes, 0, dataElement, tagBytes.Length + dataLengthBytes.Length + vrBytes.Length, dataBytes.Length);
            
             readBinary =  new BinaryReader(new MemoryStream(dataElement),new System.Text.UTF8Encoding());
            byte[] actualGroup = new byte[2];
            byte[] actualElement = new byte[2];
            byte[] actualVR = new byte[2];
            byte[] actualDataLength = new byte[2];
            byte[] actualData = new byte[8];
            // read bytes of the dataElement 
            readBinary.Read(actualGroup,0,2);
            readBinary.Read(actualElement,0,2);
            readBinary.Read(actualVR,0,2);
            readBinary.Read(actualDataLength,0,2);
            readBinary.Read(actualData,0,data.Length);

            Assert.AreEqual(expectedGroup[0], actualGroup[0] );
            Assert.AreEqual(expectedGroup[1], actualGroup[1]);
            Assert.AreEqual(expectedElement[0], actualElement[0]);
            Assert.AreEqual(expectedElement[1], actualElement[1]);
            Assert.AreEqual(expectedValueRepresentation[0], actualVR[0]);
            Assert.AreEqual(expectedValueRepresentation[1], actualVR[1]);
            Assert.AreEqual(expectedDataLength[0], actualDataLength[0]);
            Assert.AreEqual(expectedDataLength[1], actualDataLength[1]);
            for(int i=0;i< actualData.Length;++i){
                Assert.AreEqual(dataBytes[i], actualData[i]);
            }
        }

        [TestMethod]
        public void TestDecodingExplicitLittleEndianShort()
        {
            string tagGroupString    = "0010";
            string tagElementString  = "0010";
            string valueString       = "Smith^Jo";
            string valueLengthString = valueString.ToString();

            byte[] encodedByteArray  = {16,   0, //tagGroup    - 0010
                                        16,   0, //tagElement  - 0010
                                        80,  78, //VRType      - PN
                                         8,   0, //valueLength - 
                                       83, 109, 105, 116, 104, 94, 74, 111};

            EvilDICOM.Core.DICOMObject dicom_object;
            dicom_object = DICOMObjectReader.ReadObject(encodedByteArray, TransferSyntax.EXPLICIT_VR_LITTLE_ENDIAN);
            
            Tag tag = new Tag(tagGroupString, tagElementString);

            Assert.AreEqual(valueString, dicom_object.TryGetDataValue<string>(tag, null).ToString());
        }

        [TestMethod]
        public void TestDecodingExplicitLittleEndianLong()
        {
            string tagGroupString      = "0011";
            string tagElementString    = "0010";
            string expectedValueString = "83 | 109 | 105 | 116 | 104 | 94 | 74 | 111";
            
            byte[] VRType            = ByteHelper.HexStringToByteArray("0011");
            
            byte[] encodedByteArray = {17,   0,           //tagGroup    - 0011
                                       16,   0,           //tagElement  - 0010
                                       85,  78,           //VRType      - UN
                                        0,   0,           //Reserved    - 00
                                        8,   0,   0,   0, //valueLength - 
                                       83, 109, 105, 116, 104, 94, 74, 111};

            EvilDICOM.Core.DICOMObject dicom_object;
            dicom_object = DICOMObjectReader.ReadObject(encodedByteArray, TransferSyntax.EXPLICIT_VR_LITTLE_ENDIAN);

            Tag tag = new Tag(tagGroupString, tagElementString);

            Assert.AreEqual(expectedValueString, dicom_object.TryGetDataValue<byte>(tag, null).ToString());
        }

        //[TestMethod]
        //public void TestEncodingExplicitLittleEndianReservedVRField()
        //{
        //    BinaryReader readBinary;
        //    //input data for the test
        //    string tagGroup = "7FE0";
        //    string tagElement = "0010";
        //    System.Drawing.Bitmap data = new System.Drawing.Bitmap(ResourceForIntegrationTest.TestImage_256);
        //    // make sure pixel format 1 byte per pixel
        //    Bitmap dataUsed = new Bitmap(data.Width, data.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
        //    string vrString = "OB";
        //    //expected value to validate the test
        //    string reservedVR = "0000";
            
        //    byte[] expectedGroup = new byte[2];
        //    expectedGroup[0] = 224;
        //    expectedGroup[1] = 127;
        //    byte[] expectedElement = new byte[2];
        //    expectedElement[0] = 16;
        //    expectedElement[1] = 0;
        //    // String expectedTagDescription = "PatientName";
        //    byte[] expectedValueRepresentation = new byte[2];
        //    expectedValueRepresentation[0] = 79;
        //    expectedValueRepresentation[1] = 66;
        //    byte[] expectedReservedVR = new byte[2];
        //    expectedReservedVR[0] = 0;
        //    expectedReservedVR[1] = 0;

        //    // endcoding process
        //    byte[] tagGroupBytes = ByteHelper.HexStringToByteArray(tagGroup);
        //    byte[] tagElementBytes = ByteHelper.HexStringToByteArray(tagElement);
        //    //Reverse byte array to use little endian encoding
        //    Array.Reverse(tagGroupBytes);
        //    Array.Reverse(tagElementBytes);
        //    byte[] vrBytes = ByteHelper.StringToByteArray(vrString);
        //    byte[] reservedVRBytes = ByteHelper.HexStringToByteArray(reservedVR);
        //    // encoding the image
        //    MemoryStream ms = new MemoryStream();
        //    ms.Capacity = data.Height * data.Width;
        //    dataUsed.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //    byte[] dataBytes = ms.ToArray();

        //    // dataLengthBytes is already in little Endian
        //    // make sure GetBytes use unit32- bit 
        //    byte[] dataLengthBytes = BitConverter.GetBytes((int)dataBytes.Length);

        //    //Initialize the data element byte array. This byte array uses Explict little endian
        //    byte[] dataElement = new byte[tagGroupBytes.Length + tagElementBytes.Length + vrBytes.Length + reservedVRBytes.Length + dataLengthBytes.Length + dataBytes.Length];

        //    //Copy tag, length of data and data in dataElement
        //    System.Buffer.BlockCopy(tagGroupBytes, 0, dataElement, 0, tagGroupBytes.Length);
        //    System.Buffer.BlockCopy(tagElementBytes, 0, dataElement, tagGroupBytes.Length, tagElementBytes.Length);
        //    System.Buffer.BlockCopy(vrBytes, 0, dataElement, tagGroupBytes.Length + tagElementBytes.Length, vrBytes.Length);
        //    System.Buffer.BlockCopy(reservedVRBytes, 0, dataElement, tagGroupBytes.Length + tagElementBytes.Length + vrBytes.Length, reservedVRBytes.Length);
        //    System.Buffer.BlockCopy(dataLengthBytes, 0, dataElement, tagGroupBytes.Length + tagElementBytes.Length + vrBytes.Length + reservedVRBytes.Length, dataLengthBytes.Length);
        //    System.Buffer.BlockCopy(dataBytes, 0, dataElement, tagGroupBytes.Length + tagElementBytes.Length + dataLengthBytes.Length + vrBytes.Length + reservedVRBytes.Length, dataBytes.Length);

        //    readBinary = new BinaryReader(new MemoryStream(dataElement), new System.Text.UTF8Encoding());
        //    byte[] actualGroup = new byte[2];
        //    byte[] actualElement = new byte[2];
        //    byte[] actualVR = new byte[2];
        //    byte[] actualReservedVR = new byte[2];
        //    byte[] actualDataLength = new byte[4];
        //    byte[] actualData = new byte[dataBytes.Length];
        //    // read bytes of the dataElement 
        //    readBinary.Read(actualGroup, 0, 2);
        //    readBinary.Read(actualElement, 0, 2);
        //    readBinary.Read(actualVR, 0, 2);
        //    readBinary.Read(actualReservedVR, 0, 2);
        //    readBinary.Read(actualDataLength, 0, 4);
        //    readBinary.Read(actualData, 0, dataBytes.Length);

        //    Assert.AreEqual(expectedGroup[0], actualGroup[0]);
        //    Assert.AreEqual(expectedGroup[1], actualGroup[1]);
        //    Assert.AreEqual(expectedElement[0], actualElement[0]);
        //    Assert.AreEqual(expectedElement[1], actualElement[1]);
        //    Assert.AreEqual(expectedValueRepresentation[0], actualVR[0]);
        //    Assert.AreEqual(expectedValueRepresentation[1], actualVR[1]);
        //    Assert.AreEqual(expectedReservedVR[0], actualReservedVR[0]);
        //    Assert.AreEqual(expectedReservedVR[1], actualReservedVR[1]);
        //    for (int i = 0; i < actualData.Length; ++i)
        //    {
        //        Assert.AreEqual(dataBytes[i], actualData[i]);
        //    }
        //} 
  
           [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReadDicomObjectWithNullBinaryReaderExplicitLittleEndian()
        {
            DICOMBinaryReader dr = null;
            var dicomObj = DICOMObjectReader.ReadObject(dr, TransferSyntax.EXPLICIT_VR_LITTLE_ENDIAN);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestReadDicomObjectWithNullByteArrayExplicitLittleEndian()
        {
            byte[] dataElement = null;
            var dicomObj = DICOMObjectReader.ReadObject(dataElement, TransferSyntax.EXPLICIT_VR_LITTLE_ENDIAN);

        }
    
  
    }
}
