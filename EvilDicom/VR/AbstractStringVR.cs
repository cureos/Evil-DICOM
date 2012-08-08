using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EvilDicom.Components;

namespace EvilDicom
{
    namespace VR
    {
        public class AbstractStringVR : DICOMElement
        {
            public virtual string Data
            {
                set
                {
                    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                    //Check to make sure the string has an even amount of characters
                    //If not add space character afterwards
                    if (value.Length % 2 == 0)
                    {
                        ByteData = enc.GetBytes(value);
                    }
                    else
                    {
                        ByteData = enc.GetBytes(value + '\0');
                    }

                }
                get
                {
                    System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                    return enc.GetString(ByteData, 0, ByteData.Length).TrimEnd(new char[] { '\0' });
                }
            }

            public override string[] DataAsStringArray()
            {
                return new string[] { Data };
            }
        }
    }
}


//Copyright © 2012 Rex Cardan, Ph.D


