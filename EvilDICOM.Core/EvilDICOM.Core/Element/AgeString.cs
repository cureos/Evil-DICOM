<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class AgeString : AbstractElement<string>
    {
        public AgeString() { }

        public AgeString(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        public Age Age
        {
            get
            {
                return StringDataParser.ParseAgeString(Data);
            }
            set
            {
                Data = StringDataComposer.ComposeAgeString(value);
            }
        }

        #region Overrides of AbstractElement<string>

        public override VR VR
        {
            get { return VR.AgeString; }
        }

        #endregion
    }

    public class Age
    {
        public int Number { get; set; }
        public Unit Units { get; set; }

        public enum Unit { DAYS, WEEKS, MONTHS, YEARS }
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
    public class AgeString : AbstractElement<string>
    {
        public AgeString() { }

        public AgeString(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.AgeString;
        }

        public Age Age
        {
            get
            {
                return StringDataParser.ParseAgeString(Data);
            }
            set
            {
                Data = StringDataComposer.ComposeAgeString(value);
            }
        }
    }

    public class Age
    {
        public int Number { get; set; }
        public Unit Units { get; set; }

        public enum Unit { DAYS, WEEKS, MONTHS, YEARS }
    }
}
>>>>>>> upstream/master
