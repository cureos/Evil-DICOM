using System;
using EvilDICOM.Core.IO.Reading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvilDICOM.Core.Tests
{
    [TestClass]
    public class TestBinaryReader
    {
        /// <summary>
        /// Creating binaryReader with null argument
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestBinaryReader_001()
        {
            //Jignesh commit test
            byte[] dataElement = null;
            DICOMBinaryReader dr = new DICOMBinaryReader(dataElement);
        }
    }
}
