namespace EvilDICOM.Core.Element
{
    public sealed class SignedShort : AbstractElement<short?>
    {
        public SignedShort() { }

        public SignedShort(Tag tag, short? data)
        {
            Tag = tag;
            Data = data;
        }

    }
}