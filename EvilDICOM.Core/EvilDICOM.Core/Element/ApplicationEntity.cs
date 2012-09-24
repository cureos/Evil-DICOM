﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class ApplicationEntity : AbstractElement, IDICOMString
    {
        public string Data { get; set; }

        public ApplicationEntity() { }

        public ApplicationEntity(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }
    }
}
