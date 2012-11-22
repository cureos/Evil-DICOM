<<<<<<< HEAD
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
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class UnsignedShort : AbstractElement<ushort?>
    {
        public UnsignedShort() { }

        public UnsignedShort(Tag tag, ushort? data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.UnsignedShort;
        }
    }
>>>>>>> upstream/master
}