<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class SignedLong : AbstractElement<int?>
    {
        public SignedLong() { }

        public SignedLong(Tag tag, int? data)
        {
            Tag = tag;
            Data = data;
        }

        #region Overrides of AbstractElement<int?>

        public override VR VR
        {
            get { return VR.SignedLong; }
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
    public class SignedLong : AbstractElement<int?>
    {      
        public SignedLong() { }

        public SignedLong(Tag tag, int? data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.SignedLong;
        }
    }
>>>>>>> upstream/master
}