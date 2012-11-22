<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class CodeString : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.CodeString; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(50, value); }
        }

        public CodeString() { }

        public CodeString(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.IO.Data;
using EvilDICOM.Core.Interfaces;

namespace EvilDICOM.Core.Element
{
    public class CodeString : AbstractElement<string>
    {
        public new string Data
        {
            get { return base.Data; }
            set { base.Data = DataRestriction.EnforceLengthRestriction(50, value); }
        }

        public CodeString() { }

        public CodeString(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.CodeString;
        }
    }
}
>>>>>>> upstream/master
