using EvilDICOM.Core.Enums;

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

        #region Overrides of AbstractElement<short?>

        public override VR VR
        {
            get { return VR.SignedShort; }
        }

        #endregion
    }
}