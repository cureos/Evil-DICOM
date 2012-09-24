using EvilDICOM.Core.Enums;

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

        #region Overrides of AbstractElement<uint?>

        public override VR VR
        {
            get { return VR.UnsignedLong; }
        }

        #endregion
    }
}