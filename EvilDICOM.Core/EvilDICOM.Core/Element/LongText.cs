using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class LongText : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.LongText; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(10240, value); }
        }

        public LongText() { }

        public LongText(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }
    }
}