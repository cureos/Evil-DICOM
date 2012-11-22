<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class ShortText : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.ShortText; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(1024, value); }
        }

        public ShortText() { }

        public ShortText(Tag tag, string data)
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
    public class ShortText : AbstractElement<string>
    {
        public string Data
        {
            get { return base.Data; }
            set { base.Data = DataRestriction.EnforceLengthRestriction(1024, value); }
        }

        public ShortText() { }

        public ShortText(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.ShortText;
        }

        private string _data;
    }
>>>>>>> upstream/master
}