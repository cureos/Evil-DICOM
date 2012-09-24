﻿using EvilDICOM.Core.Enums;

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

        #region Overrides of AbstractElement<ushort?>

        public override VR VR
        {
            get { return VR.UnsignedShort; }
        }

        #endregion
    }
}