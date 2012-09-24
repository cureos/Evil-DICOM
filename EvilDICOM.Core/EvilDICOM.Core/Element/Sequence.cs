using System;
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
