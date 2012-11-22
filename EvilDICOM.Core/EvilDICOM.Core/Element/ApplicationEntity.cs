<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;

namespace EvilDICOM.Core.Element
{
    public sealed class ApplicationEntity : AbstractElement<string>
    {
        public ApplicationEntity() { }

        public ApplicationEntity(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        #region Overrides of AbstractElement<string>

        public override VR VR
        {
            get { return VR.ApplicationEntity; }
        }

        #endregion
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class ApplicationEntity : AbstractElement<string>
    {
        public ApplicationEntity() { }

        public ApplicationEntity(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.ApplicationEntity;
        }
    }
}
>>>>>>> upstream/master
