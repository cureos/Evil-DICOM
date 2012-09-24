namespace EvilDICOM.Core.Element
{
    public sealed class UnsignedLong : AbstractElement<uint?>
    {
        public UnsignedLong() { }

        public UnsignedLong(Tag tag, uint? data)
        {
            Tag = tag;
            Data = data;
        }
    }
}