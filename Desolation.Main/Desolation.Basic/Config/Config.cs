using System.Xml.Serialization;
using Desolation.Basic.Config.Options;

namespace Desolation.Basic.Config
{
    [XmlRoot]
    public class Config
    {
        [XmlElement]
        public WindowSettingsOption WindowSettings { get; set; } = new WindowSettingsOption();
    }
}
