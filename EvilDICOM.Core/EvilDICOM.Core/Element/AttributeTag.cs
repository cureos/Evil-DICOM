using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class AttributeTag : AbstractElement<Tag>
    {
        public AttributeTag() { }

        public AttributeTag(Tag tag, Tag data)
        {
            Tag = tag;
            Data = data;
        }
    }

    public class Tag
    {
        public Tag(string group, string element)
        {
            Group = DataRestriction.EnforceLengthRestriction(4, group);
            Element = DataRestriction.EnforceLengthRestriction(4, element);
        }

        public Tag(string completeID)
        {
            CompleteID = DataRestriction.EnforceLengthRestriction(8, completeID);
        }

        public string Group { get; set; }
        public string Element { get; set; }
        public string CompleteID
        {
            get
            {
                return Group + Element;
            }
            set
            {
                var completeID = DataRestriction.EnforceLengthRestriction(8, value);
                Group = completeID.Substring(0, 4);
                Element = completeID.Substring(4, 4);
            }
        }
    }
}
