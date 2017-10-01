using System;
using System.Xml.Serialization;

namespace Desolation.Basic.Config.Options
{
    [Serializable]
    public sealed class WindowSettingsOption
    {
        [XmlAttribute]
        public int Width { get; set; } = 800;

        [XmlAttribute]
        public int Height { get; set; } = 600;
    }
}
