<<<<<<< HEAD
﻿using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.Enums;

namespace EvilDICOM.Core.Element
{
    public abstract class AbstractElement<T> : IDICOMElement
    {
        protected T _data;

        public override string ToString()
        {
            return string.Format("VR = {0}, Tag = {1},{2}", VR, Tag.Group, Tag.Element);
        }

        public Tag Tag { get; set; }

        public abstract VR VR { get; }

        public object GetData()
        {
            return Data;
        }

        public void SetData(object data)
        {
            Data = (T)data;
        }

        public virtual T Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Dictionaries;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.Enums;

namespace EvilDICOM.Core.Element
{
    public abstract class AbstractElement<T> : IDICOMElement
    {
         public override string ToString()
        {
            return string.Format("VR = {0}, Tag = {1},{2}", VR.ToString(), Tag.Group, Tag.Element);
        }

         public Tag Tag
         {
             get;
             set;
         }

         public VR VR
         {
             get;
             set;
         }

         public T Data { get; set; }
    }
}
>>>>>>> upstream/master
