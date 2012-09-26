using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class ShortText : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.ShortText; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(1024, value); }
        }

        public ShortText() { }

        public ShortText(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }
    }
}