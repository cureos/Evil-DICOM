using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class IntegerString : AbstractElement<int[]>
    {
        public IntegerString() { }

        public IntegerString(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseIntegerString(data);
        }
    }
}