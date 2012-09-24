using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class DateTime : AbstractElement<System.DateTime?>
    {
        public DateTime() { }

        public DateTime(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseDateTime(data);
        }

        #region Overrides of AbstractElement<DateTime?>

        public override VR VR
        {
            get { return VR.DateTime; }
        }

        #endregion
    }
}