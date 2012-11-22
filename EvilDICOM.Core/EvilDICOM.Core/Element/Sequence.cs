<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using EvilDICOM.Core.Enums;

namespace EvilDICOM.Core.Element
{
    public sealed class Sequence : AbstractElement<List<DICOMObject>> 
    {
        public List<DICOMObject> Items { get; set; }

        public override VR VR
        {
            get { return VR.Sequence; }
        }

        public override List<DICOMObject> Data
        {
            get { return Items; }
            set { throw new NotSupportedException(); }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Writing;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class Sequence : AbstractElement<List<DICOMObject>>
    {
        public Sequence()
        {
            VR = Enums.VR.Sequence;
            Items = new List<DICOMObject>();
        }
        /// <summary>
        /// Alternate property name for data (with a clearer name)
        /// </summary>
        public List<DICOMObject> Items
        {
            get
            {
                return base.Data;
            }
            set
            {
                base.Data = value;
            }
        }
    }
}
>>>>>>> upstream/master
