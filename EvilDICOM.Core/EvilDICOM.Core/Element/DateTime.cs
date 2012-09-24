using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class DateTime : AbstractElement<System.DateTime?>
    {
        public DateTime() { }

        public DateTime(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseDateTime(data);
        }
    }
}