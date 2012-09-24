using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class DecimalString : AbstractElement<double[]>
    {
        public DecimalString() { }

        public DecimalString(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseDecimalString(data);
        }

        #region Overrides of AbstractElement<double[]>

        public override VR VR
        {
            get { return VR.DecimalString; }
        }

        #endregion
    }
}