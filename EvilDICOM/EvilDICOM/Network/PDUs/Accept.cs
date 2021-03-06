﻿using System.Collections.Generic;
using System.IO;
using System.Text;
using EvilDICOM.Core.IO.Writing;
using EvilDICOM.Network.Enums;
using EvilDICOM.Network.Interfaces;
using EvilDICOM.Network.PDUs.Items;
using EvilDICOM.Core.Helpers;

namespace EvilDICOM.Network.PDUs
{
    public class Accept : IPDU
    {
        public int ProtocolVersion { get; set; }
        public string CalledEntityTitle { get; set; }
        public string CallingEntityTitle { get; set; }
        public string ApplicationContext { get; set; }
        public List<PresentationContext> PresentationContexts { get; set; }
        public UserInfo UserInfo { get; set; }

        public byte[] Write()
        {
            var written = new byte[0];
            using (var stream = new MemoryStream())
            {
                using (var dw = new DICOMBinaryWriter(stream))
                {
                    dw.Write((byte)PDUType.A_ASSOC_ACCEPT);
                    dw.WriteNullBytes(1); //Reserved Null byte
                    byte[] body = WriteBody();
                    LengthWriter.WriteBigEndian(dw, body.Length, 4);
                    dw.Write(body);
                    written = stream.ToArray();
                }
            }
            return written;
        }

        public PDUType Type
        {
            get { return PDUType.A_ASSOC_ACCEPT; }
        }

        private byte[] WriteBody()
        {
            var body = new byte[0];
            var stream = new MemoryStream();
            using (var dw = new DICOMBinaryWriter(stream))
            {
                //Main body
                LengthWriter.WriteBigEndian(dw, ProtocolVersion, 2); //Protocol Version
                dw.WriteNullBytes(2); //Reserved Null bytes
                dw.Write(CalledEntityTitle.PadRight(16));
                dw.Write(CallingEntityTitle.PadRight(16));
                dw.WriteNullBytes(32); //Reserved Null bytes
                ItemWriter.WriteApplicationContext(dw, ApplicationContext);
                foreach (PresentationContext pc in PresentationContexts)
                {
                    ItemWriter.WritePresentationCtxAcceptType(dw, pc);
                }
                ItemWriter.WriteUserInfo(dw, UserInfo);
                body = stream.ToArray();
            }

            return body;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("A-ACCEPT");
            sb.AppendLine("-----------------------------");
            sb.AppendLine(string.Format("Called Entity Title : {0}", CalledEntityTitle));
            sb.AppendLine(string.Format("Calling Entity Title : {0}", CallingEntityTitle));
            sb.AppendLine(string.Format("Application Context : {0}", ApplicationContext));
            sb.AppendLine(string.Format("Protocol Version : {0}", ProtocolVersion));
            sb.AppendLine();
            sb.AppendLine(UserInfo.ToString());
            foreach (PresentationContext ctx in PresentationContexts)
            {
                sb.AppendLine(ctx.ToString());
            }
            sb.AppendLine();
            return sb.ToString();
        }

        public static Accept Generate(Request request, List<PresentationContext> contexts)
        {
            var accept = new Accept
            {
                ApplicationContext = request.ApplicationContext,
                CalledEntityTitle = request.CalledEntityTitle,
                CallingEntityTitle = request.CallingEntityTitle,
                PresentationContexts = contexts,
                ProtocolVersion = request.ProtocolVersion,
                UserInfo = new UserInfo
                {
                    AsynchronousOperations = null,
                    ImplementationUID = Constants.EVIL_DICOM_IMP_UID,
                    ImplementationVersion = Constants.EVIL_DICOM_IMP_VERSION,
                    MaxPDULength = request.UserInfo.MaxPDULength
                }
            };
            return accept;
        }
    }
}