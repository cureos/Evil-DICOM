﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class LongText : AbstractElement, IDICOMString
    {
        public string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(10240, value); }
        }

        public LongText() { }

        public LongText(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        private string _data;
    }
}