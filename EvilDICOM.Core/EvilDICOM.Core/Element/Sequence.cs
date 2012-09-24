using System;
using System.Collections.Generic;

namespace EvilDICOM.Core.Element
{
    public sealed class Sequence : AbstractElement<List<DICOMObject>> 
    {
        public List<DICOMObject> Items { get; set; }

        public override List<DICOMObject> Data
        {
            get { return Items; }
            set { throw new NotSupportedException(); }
        }
    }
}
