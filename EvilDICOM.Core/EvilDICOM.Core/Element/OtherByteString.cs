namespace EvilDICOM.Core.Element
{
    public sealed class OtherByteString : AbstractElement<byte[]>
    {
        public OtherByteString() { }

        public OtherByteString(Tag tag, byte[] data)
        {
            Tag = tag;
            Data = data;
        }
    }
}