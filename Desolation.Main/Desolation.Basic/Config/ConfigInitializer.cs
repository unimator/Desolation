using System;
using System.IO;
using Desolation.Basic.Helpers;
using Desolation.Basic.Logger;

namespace Desolation.Basic.Config
{
    public static class ConfigInitializer
    {
        public static readonly string ConfigFileName = Resources.ConfigFileName;

        public static Config LoadDefaultConfig()
        {
            return LoadConfig(ConfigFileName);
        }

        public static Config LoadConfig(string configFileName)
        {
            Config config;
            try
            {
                string configXml = File.ReadAllText(configFileName);
                config = XmlHelper.FromXml<Config>(configXml);
            }
            catch (Exception)
            {
                Logger.Logger.LogMessage(LogMessages.readConfigError);
                throw;
            }

            return config;
        }
    }
}