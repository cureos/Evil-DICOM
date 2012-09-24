using EvilDICOM.Core.Enums;

namespace EvilDICOM.Core.Element
{
    public sealed class FloatingPointDouble : AbstractElement<double?>
    {
        public FloatingPointDouble() { }

        public FloatingPointDouble(Tag tag, double? data)
        {
            Tag = tag;
            Data = data;
        }

        #region Overrides of AbstractElement<double?>

        public override VR VR
        {
            get { return VR.FloatingPointDouble; }
        }

        #endregion
    }
}