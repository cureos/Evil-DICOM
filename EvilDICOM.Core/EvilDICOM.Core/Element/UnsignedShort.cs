namespace EvilDICOM.Core.Element
{
    public sealed class UnsignedShort : AbstractElement<ushort?>
    {
        public UnsignedShort() { }

        public UnsignedShort(Tag tag, ushort? data)
        {
            Tag = tag;
            Data = data;
        }
    }
}