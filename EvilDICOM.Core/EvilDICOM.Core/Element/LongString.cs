using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class LongString : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.LongString; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(64, value); }
        }

        public LongString() { }

        public LongString(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        private string _data;
    }
}
