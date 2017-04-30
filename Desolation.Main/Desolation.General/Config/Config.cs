using System;
using System.IO;
using System.Xml.Serialization;
using Desolation.General.ArgumentsParser;
using Desolation.General.Logger;

namespace Desolation.General.Config
{
    [Serializable]
    public class Config
    {
        private static readonly string ConfigFileName = Resource.ConfigFileName;

        public WindowSettings WindowSettings { get; set; } = new WindowSettings();

        public void ApplyParameters(Parameters parameters)
        {
            if (parameters.Resolution != null)
            {
                WindowSettings.Height = parameters.Resolution.Height;
                WindowSettings.Width = parameters.Resolution.Width;
            }
        }

        public static Config LoadConfig(string configFileName)
        {
            Config config;
            if (string.IsNullOrEmpty(configFileName))
                configFileName = ConfigFileName;

            try
            {
                if (!File.Exists(configFileName))
                {
                    config = new Config();
                    Logger.Logger.LogMessage(LogMessages.readConfigError);
                }
                else
                {
                    string configXml = File.ReadAllText(configFileName);
                    config = Config.FromXml(configXml);
                }
            }
            catch (Exception)
            {
                Logger.Logger.LogMessage(LogMessages.readConfigError);
                throw;
            }
            return config;
        }

        public static string ToXml(Config config)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));

            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, config);
                return stringWriter.ToString();
            }
        }

        public static Config FromXml(string config)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));

            using (StringReader stringReader = new StringReader(config))
            {
                return (Config) xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}
