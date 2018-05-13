using System.Xml.Serialization;
using Desolation.Basic.Config.Options.Entities;

namespace Desolation.Basic.Config
{
    [XmlRoot]
    public class Config
    {
        [XmlElement]
        public WindowSettingsOption WindowSettings { get; set; } = new WindowSettingsOption();
    }
}
