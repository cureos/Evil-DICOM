using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class Time : AbstractElement<System.DateTime?>
    {
        public Time() { }

        public Time(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseTime(data);
        }
    }
}