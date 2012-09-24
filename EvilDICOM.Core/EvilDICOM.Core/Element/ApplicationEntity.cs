namespace EvilDICOM.Core.Element
{
    public sealed class ApplicationEntity : AbstractElement<string>
    {
        public ApplicationEntity() { }

        public ApplicationEntity(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }
    }
}
