<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;

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
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class OtherFloatString : AbstractElement<byte[]>
    {
        public OtherFloatString() { }

        public OtherFloatString(Tag tag, byte[] data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.OtherFloatString;
        }
    }
>>>>>>> upstream/master
}