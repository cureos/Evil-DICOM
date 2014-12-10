using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    /// <summary>
    /// Encapsulates the UniformResource VR type
    /// </summary>
    /// 
    /// <remarks>
    /// This new VR has been added in the 2014 version of the DICOM standard, and conforms to RFC 3986, section 2.
    /// </remarks>
    public class UniformResource : AbstractElement<string>
    {
        /// <summary>
        /// Data is overriden to enforce length restriction
        /// </summary>
        public new string Data
        {
            get { return base.DataContainer.SingleValue; }
            set { base.DataContainer = base.DataContainer ?? new DICOMData<string>(); base.DataContainer.SingleValue = DataRestriction.EnforceLengthRestriction(uint.MaxValue - 1, value); }
        }

        public UniformResource() : base() { }

        public UniformResource(Tag tag, string data)
            : base()
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.UnlimitedText;
        }
    }
}
