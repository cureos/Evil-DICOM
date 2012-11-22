<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class UnlimitedText : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.UnlimitedText; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(uint.MaxValue - 1, value); }
        }

        public UnlimitedText() { }

        public UnlimitedText(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }
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
    public class UnlimitedText : AbstractElement<string>
    {
        public string Data
        {
            get { return base.Data; }
            set { base.Data = DataRestriction.EnforceLengthRestriction(uint.MaxValue - 1, value); }
        }

        public UnlimitedText() { }

        public UnlimitedText(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.UnlimitedText;
        }
    }
>>>>>>> upstream/master
}