using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class CodeString : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.CodeString; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(50, value); }
        }

        public CodeString() { }

        public CodeString(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        private string _data;
    }
}
