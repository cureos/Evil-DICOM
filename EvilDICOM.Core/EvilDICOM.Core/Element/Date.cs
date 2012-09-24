using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class Date : AbstractElement<System.DateTime?>
    {
        public Date() { }

        public Date(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseDate(data);
        }

        #region Overrides of AbstractElement<DateTime?>

        public override VR VR
        {
            get { return VR.Date; }
        }

        #endregion
    }
}