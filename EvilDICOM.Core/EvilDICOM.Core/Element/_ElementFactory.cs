﻿using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.IO.Reading;
using EvilDICOM.Core.IO.Data;

namespace EvilDICOM.Core.Element
{
    public class ElementFactory
    {
        public static IDICOMElement GenerateElement(VR vr, Tag tag, object data,TransferSyntax syntax)
        {
            //HANDLE NUMBERS
            if (syntax == TransferSyntax.EXPLICIT_VR_BIG_ENDIAN)
            {
                switch (vr)
                {
                    case VR.AttributeTag: return new AttributeTag(tag, BigEndianReader.ReadTag(data as byte[]));
                    case VR.FloatingPointDouble: return new FloatingPointDouble(tag, BigEndianReader.ReadDoublePrecision(data as byte[]));
                    case VR.FloatingPointSingle: return new FloatingPointSingle(tag, BigEndianReader.ReadSinglePrecision(data as byte[]));
                    case VR.SignedLong: return new SignedLong(tag, BigEndianReader.ReadSignedLong(data as byte[]));
                    case VR.SignedShort: return new SignedShort(tag, BigEndianReader.ReadSignedShort(data as byte[]));
                    case VR.UnsignedLong: return new UnsignedLong(tag, BigEndianReader.ReadUnsignedLong(data as byte[]));
                    case VR.UnsignedShort: return new UnsignedShort(tag, BigEndianReader.ReadUnsignedShort(data as byte[]));
                }
            }
            else
            {
                switch (vr)
                {
                    case VR.AttributeTag: return new AttributeTag(tag, LittleEndianReader.ReadTag(data as byte[]));
                    case VR.FloatingPointDouble: return new FloatingPointDouble(tag, LittleEndianReader.ReadDoublePrecision(data as byte[]));
                    case VR.FloatingPointSingle: return new FloatingPointSingle(tag, LittleEndianReader.ReadSinglePrecision(data as byte[]));
                    case VR.SignedLong: return new SignedLong(tag, LittleEndianReader.ReadSignedLong(data as byte[]));
                    case VR.SignedShort: return new SignedShort(tag, LittleEndianReader.ReadSignedShort(data as byte[]));
                    case VR.UnsignedLong: return new UnsignedLong(tag, LittleEndianReader.ReadUnsignedLong(data as byte[]));
                    case VR.UnsignedShort: return new UnsignedShort(tag, LittleEndianReader.ReadUnsignedShort(data as byte[]));
                }
            }  
           //HANDLE ALL OTHERS
            switch (vr)
            {
                //HANDLE STRINGS
                case VR.AgeString:
                case VR.ApplicationEntity:
                case VR.CodeString:
                case VR.Date:
                case VR.DateTime:
                case VR.DecimalString:
                case VR.IntegerString:
                case VR.LongString:
                case VR.LongText:
                case VR.PersonName:
                case VR.ShortString:
                case VR.ShortText:
                case VR.Time:
                case VR.UnlimitedText:
                case VR.UniqueIdentifier:
                    return ReadString(vr, tag, data);

                //HANDLE BYTE DATA
                case VR.Sequence:
                    return new Sequence { Tag = tag, Items = SequenceReader.ReadItems(data as byte[], syntax) };
                case VR.OtherByteString:
                    return new OtherByteString(tag, data as byte[]);
                case VR.OtherFloatString:
                    return new OtherFloatString(tag, data as byte[]);
                case VR.OtherWordString:
                    return new OtherWordString(tag, data as byte[]);                  
                default:
                    return new Unknown(tag, data as byte[]);               
            }
        }

        /// <summary>
        /// Reads string data and creates the appropriate DICOM element
        /// </summary>
        /// <param name="vr">value representation</param>
        /// <param name="tag">Tag of the object</param>
        /// <param name="data">the string data as an object (fresh from the DICOM reader)</param>
        /// <returns></returns>
        private static IDICOMElement ReadString(VR vr, Tag tag, object data)
        {
            switch (vr)
            {
                case VR.AgeString:
                    return new AgeString(tag, DICOMString.Read(data as byte[]));
                case VR.ApplicationEntity:
                    return new ApplicationEntity(tag, DICOMString.Read(data as byte[]));
                case VR.CodeString:
                    return new CodeString(tag, DICOMString.Read(data as byte[]));
                case VR.Date:
                    return new Date(tag, DICOMString.Read(data as byte[]));
                case VR.DateTime:
                    return new DateTime(tag, DICOMString.Read(data as byte[]));
                case VR.DecimalString:
                    return new DecimalString(tag, DICOMString.Read(data as byte[]));
                case VR.IntegerString:
                    return new IntegerString(tag, DICOMString.Read(data as byte[]));
                case VR.LongString:
                    return new LongString(tag, DICOMString.Read(data as byte[]));
                case VR.LongText:
                    return new LongText(tag, DICOMString.Read(data as byte[]));
                case VR.PersonName:
                    return new PersonName(tag, DICOMString.Read(data as byte[]));
                case VR.ShortString:
                    return new ShortString(tag, DICOMString.Read(data as byte[]));
                case VR.ShortText:
                    return new ShortText(tag, DICOMString.Read(data as byte[]));
                case VR.Time:
                    return new Time(tag, DICOMString.Read(data as byte[]));
                case VR.UnlimitedText:
                    return new UnlimitedText(tag, DICOMString.Read(data as byte[]));
                case VR.UniqueIdentifier:
                    return new UniqueIdentifier(tag, DICOMString.Read(data as byte[]));
                default:
                    return new Unknown(tag, data as byte[]);
            }
        }
    }
}
