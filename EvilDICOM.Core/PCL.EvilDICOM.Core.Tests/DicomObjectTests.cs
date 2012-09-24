using System.IO;
using NUnit.Framework;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.IO.Reading;

namespace EvilDICOM.Core.Tests
{
    [TestFixture]
    public class DicomObjectTests
    {
        [Test]
        public void ReplaceOrAdd_ElementExists_ValueReplaced()
        {
            using (var stream = File.OpenRead("Data/ct.9.dcm"))
            {
                const string expected = "UNITTEST";

                var dicomFile = DICOMFileReader.Read(stream);
                var patientIdElem = new ShortString(TagHelper.PATIENT_ID, expected);
                dicomFile.ReplaceOrAdd(patientIdElem);

                var actual = dicomFile.FindFirst(TagHelper.PATIENT_ID).GetData() as string;
                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void Replace_ElementExistButDifferentType_ValueUnchanged()
        {
            using (var stream = File.OpenRead("Data/ct.9.dcm"))
            {
                var tag = TagHelper.PATIENT_NAME;
                var dicomFile = DICOMFileReader.Read(stream);
                var expected = dicomFile.FindFirst(tag).GetData() as string;

                var patientIdElem = new CodeString(tag, "Test^Unit^^^");
                dicomFile.Replace(patientIdElem);

                var actual = dicomFile.FindFirst(tag).GetData() as string;
                Assert.AreEqual(expected, actual);
            }
        }

        [Test]
        public void ReplaceOrAdd_ElementExistButDifferentType_ValueUnchanged()
        {
            using (var stream = File.OpenRead("Data/ct.9.dcm"))
            {
                const string expected = "Test^Unit^^^";

                var tag = TagHelper.PATIENT_NAME;
                var dicomFile = DICOMFileReader.Read(stream);
                var before = dicomFile.FindFirst(tag).GetData() as string;
                Assert.AreNotEqual(expected, before);

                var patientIdElem = new CodeString(tag, expected);
                dicomFile.ReplaceOrAdd(patientIdElem);

                var actual = dicomFile.FindFirst(tag).GetData() as string;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}