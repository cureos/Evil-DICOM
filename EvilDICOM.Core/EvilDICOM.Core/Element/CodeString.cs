﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.IO.Data;
using EvilDICOM.Core.Interfaces;

namespace EvilDICOM.Core.Element
{
    /// <summary>
    /// Encapsulates the CodeString VR type
    /// </summary>
    public class CodeString : AbstractElement<string>
    {
        /// <summary>
        /// Data is overriden to enforce length restriction
        /// </summary>
        public new string Data
        {
            get { return base.DataContainer.SingleValue; }
            set { base.DataContainer = base.DataContainer ?? new DICOMData<string>(); base.DataContainer.SingleValue = DataRestriction.EnforceLengthRestriction(50, value); }
        }

        public CodeString() : base() { VR = Enums.VR.CodeString; }

        public CodeString(Tag tag, string data)
            : base()
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.CodeString;
        }
    }
}
