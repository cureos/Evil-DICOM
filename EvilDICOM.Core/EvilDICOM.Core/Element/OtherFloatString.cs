namespace EvilDICOM.Core.Element
{
    public sealed class OtherFloatString : AbstractElement<byte[]>
    {
        public OtherFloatString() { }

        public OtherFloatString(Tag tag, byte[] data)
        {
            Tag = tag;
            Data = data;
        }
    }
}