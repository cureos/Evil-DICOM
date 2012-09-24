using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Element;

namespace EvilDICOM.Core.Interfaces
{
    public interface IDICOMElement
    {
        Tag Tag { get; set; }

        VR VR { get; set; }

        object GetData();

        void SetData(object data);
    }
}
