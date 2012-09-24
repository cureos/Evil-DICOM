using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class UniqueIdentifier : AbstractElement<string>
    {
        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(64, value); }
        }

        public UniqueIdentifier()
        {
        }

        public UniqueIdentifier(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        private string _data;    
    }
}
