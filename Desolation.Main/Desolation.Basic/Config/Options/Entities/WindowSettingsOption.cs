using System;
using System.Xml.Serialization;

namespace Desolation.Basic.Config.Options.Entities
{
    [Serializable]
    public sealed class WindowSettingsOption
    {
        [XmlAttribute]
        public int Width { get; set; } = 800;

        [XmlAttribute]
        public int Height { get; set; } = 600;

        [XmlAttribute]
        public WindowFeatures.BorderType BorderType { get; set; } = WindowFeatures.BorderType.Borderless;
    }
}
