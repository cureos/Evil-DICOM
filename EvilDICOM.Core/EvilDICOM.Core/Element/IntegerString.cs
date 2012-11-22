<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class IntegerString : AbstractElement<int[]>
    {
        public IntegerString() { }

        public IntegerString(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseIntegerString(data);
        }

        #region Overrides of AbstractElement<int[]>

        public override VR VR
        {
            get { return VR.IntegerString; }
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
    public class IntegerString : AbstractElement<int[]>
    {
        public IntegerString() { }

        public IntegerString(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseIntegerString(data);
            VR = Enums.VR.IntegerString;
        }
    }
>>>>>>> upstream/master
}