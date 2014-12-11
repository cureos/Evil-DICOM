using EvilDICOM.Core.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvilDICOM.Core.Tests
{
    [TestClass]
    public class TestByteHelper
    {
        [TestMethod]
        public void TestStringToHexString()
        {
            // input test
            string inputString = "PN";
            // expected 
            string expectedValue = "504E";
            // actual
            string actualValue = ByteHelper.StringToHexString(inputString);

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void TestStringToByteArray()
        {
            // input test
            string inputString = "Qa";
            // expected 
            byte[] expectedValue = new byte[2];
            expectedValue[0] = 81;
            expectedValue[1] = 97;
            // actual
            byte[] actualValue = ByteHelper.StringToByteArray(inputString);

            Assert.IsNotNull(actualValue);
            Assert.AreEqual(expectedValue[0], actualValue[0]);
            Assert.AreEqual(expectedValue[1], actualValue[1]);
        }
    }
}
