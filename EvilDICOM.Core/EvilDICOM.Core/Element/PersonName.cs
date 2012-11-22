<<<<<<< HEAD
﻿using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Data;
using EvilDICOM.Core.Helpers;

namespace EvilDICOM.Core.Element
{
    public sealed class PersonName : AbstractElement<string>
    {
        public override VR VR
        {
            get { return VR.PersonName; }
        }

        public override string Data
        {
            get { return _data; }
            set { _data = DataRestriction.EnforceLengthRestriction(64, value); }
        }

        public PersonName() { }

        public PersonName(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
        }

        public string FirstName
        {
            get { return PersonNameHelper.GetFirstName(Data); }
            set { Data = PersonNameHelper.SetFirstName(Data, value); }
        }

        public string MiddleName
        {
            get { return PersonNameHelper.GetMiddleName(Data); }
            set { Data = PersonNameHelper.SetMiddleName(Data, value); }
        }

        public string LastName
        {
            get { return PersonNameHelper.GetLastName(Data); }
            set { Data = PersonNameHelper.SetLastName(Data, value); }
        }
    }
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.IO.Data;
using EvilDICOM.Core.Helpers;

namespace EvilDICOM.Core.Element
{
    public class PersonName : AbstractElement<string>
    {
        public string Data
        {
            get { return base.Data; }
            set { base.Data = DataRestriction.EnforceLengthRestriction(64, value); }
        }

        public PersonName() { }

        public PersonName(Tag tag, string data)
        {
            Tag = tag;
            Data = data;
            VR = Enums.VR.PersonName;
        }

        public string FirstName
        {
            get { return PersonNameHelper.GetFirstName(Data); }
            set { Data = PersonNameHelper.SetFirstName(Data, value); }
        }

        public string MiddleName
        {
            get { return PersonNameHelper.GetMiddleName(Data); }
            set { Data = PersonNameHelper.SetMiddleName(Data, value); }
        }

        public string LastName
        {
            get { return PersonNameHelper.GetLastName(Data); }
            set { Data = PersonNameHelper.SetLastName(Data, value); }
        }
    }
>>>>>>> upstream/master
}