﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    /// <summary>
    /// Encapsulates the LongString VR type
    /// </summary>
    public class LongString : AbstractElement<string>
    {
        /// <summary>
        /// Data overriden for enforcing length restriction
        /// </summary>
        public new string Data
        {
            get { return base.DataContainer.SingleValue; }
            set { base.DataContainer = base.DataContainer ?? new DICOMData<string>(); base.DataContainer.SingleValue = DataRestriction.EnforceLengthRestriction(64, value); }
        }

        public LongString() : base() { VR = Enums.VR.LongString; }

        public LongString(Tag tag, string data)
            : base()
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.LongString;
        }
    }
}
