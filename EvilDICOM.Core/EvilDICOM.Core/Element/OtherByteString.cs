using EvilDICOM.Core.Enums;

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

        #region Overrides of AbstractElement<byte[]>

        public override VR VR
        {
            get { return VR.OtherByteString; }
        }

        #endregion
    }
}