using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public sealed class FloatingPointSingle : AbstractElement<float?>
    {
        public FloatingPointSingle() { }

        public FloatingPointSingle(Tag tag, float? data)
        {
            Tag = tag;
            Data = data;
        }
    }
}