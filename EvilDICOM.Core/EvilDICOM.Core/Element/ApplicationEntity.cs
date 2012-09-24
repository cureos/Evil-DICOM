using EvilDICOM.Core.Enums;

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
