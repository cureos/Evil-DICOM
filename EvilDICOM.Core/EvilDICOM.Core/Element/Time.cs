<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class Time : AbstractElement<System.DateTime?>
    {
        public Time() { }

        public Time(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseTime(data);
        }

        #region Overrides of AbstractElement<DateTime?>

        public override VR VR
        {
            get { return VR.Time; }
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
    public class Time : AbstractElement<System.DateTime?>
    {
        public Time() { }

        public Time(Tag tag, string data)
        {
            Tag = tag;
            Data = StringDataParser.ParseTime(data);
            VR = Enums.VR.Time;
        }
    }
>>>>>>> upstream/master
}