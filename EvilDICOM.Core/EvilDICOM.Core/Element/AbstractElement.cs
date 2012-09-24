using EvilDICOM.Core.Interfaces;
using EvilDICOM.Core.Enums;

namespace EvilDICOM.Core.Element
{
    public class AbstractElement<T> : IDICOMElement
    {
        public override string ToString()
        {
            return string.Format("VR = {0}, Tag = {1},{2}", VR, Tag.Group, Tag.Element);
        }

        public Tag Tag { get; set; }

        public VR VR { get; set; }

        public object GetData()
        {
            return Data;
        }

        public void SetData(object data)
        {
            Data = (T)data;
        }

        public virtual T Data { get; set; }
    }
}
