using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class UnlimitedText : AbstractElement<string>
    {
        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(uint.MaxValue - 1, value); }
        }

        public UnlimitedText() { }

        public UnlimitedText(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        private string _data;
    }
}