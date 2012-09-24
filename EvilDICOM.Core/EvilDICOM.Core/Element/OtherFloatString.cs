using EvilDICOM.Core.Enums;

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

        #region Overrides of AbstractElement<byte[]>

        public override VR VR
        {
            get { return VR.OtherFloatString; }
        }

        #endregion
    }
}