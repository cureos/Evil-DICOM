using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class ShortText : AbstractElement<string>
    {
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

        private string _data;
    }
}