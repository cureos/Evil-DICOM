using EvilDICOM.Core.Dictionaries;
using EvilDICOM.Core.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvilDICOM.Core.Tests
{
    [TestClass]
    public class TestVRDictionary
    {
        [TestMethod]
        public void TestVRUnlimitedTextEncoding()
        {
            // input test
            VR valueRepresentation = VR.UnlimitedText;
            // expected values
            VREncoding expectedvalueRepresentationEncoding = VREncoding.ExplicitLong;
            VREncoding actualValueRepresentation = VRDictionary.GetEncodingFromVR(valueRepresentation);
            Assert.AreEqual(expectedvalueRepresentationEncoding, actualValueRepresentation);
        }
    }
}
