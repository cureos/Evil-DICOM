using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class AgeString : AbstractElement<string>
    {
        public AgeString() { }

        public AgeString(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        public Age Age
        {
            get
            {
                return StringDataParser.ParseAgeString(Data);
            }
            set
            {
                Data = StringDataComposer.ComposeAgeString(value);
            }
        }

    }

    public class Age
    {
        public int Number { get; set; }
        public Unit Units { get; set; }

        public enum Unit { DAYS, WEEKS, MONTHS, YEARS }
    }
}
