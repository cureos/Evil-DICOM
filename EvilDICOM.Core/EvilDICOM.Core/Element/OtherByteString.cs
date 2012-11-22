<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;

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
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class OtherByteString : AbstractElement<byte[]>
    {
        public OtherByteString() { }

        public OtherByteString(Tag tag, byte[] data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.OtherByteString;
        }
    }
>>>>>>> upstream/master
}