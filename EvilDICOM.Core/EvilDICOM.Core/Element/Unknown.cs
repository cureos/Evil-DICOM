using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class Unknown : AbstractElement<byte[]>
    {
        public Unknown() { }

        public Unknown(Tag tag, byte[] data)
        {
            Tag = tag;
            Data = data;
        }

        #region Overrides of AbstractElement<byte[]>

        public override VR VR
        {
            get { return VR.Unknown; }
        }

        #endregion
    }
}
