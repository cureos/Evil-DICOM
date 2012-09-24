using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class DecimalString : AbstractElement<double[]>
    {
        public DecimalString() { }

        public DecimalString(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseDecimalString(data);
        }
    }
}