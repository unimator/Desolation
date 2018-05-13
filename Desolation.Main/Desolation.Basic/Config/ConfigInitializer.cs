using System;
using System.IO;
using Desolation.Basic.Helpers;
using Desolation.Basic.Logger;

namespace Desolation.Basic.Config
{
    public static class ConfigInitializer
    {
        public static string DefaultConfigPath
        {
            get
            {
                var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(appData, Resources.AppName, Resources.ConfigFileName);
            }
        }

        public static Config LoadDefaultConfig()
        {
            return LoadConfig(DefaultConfigPath);
        }

        public static Config LoadConfig(string configFileName)
        {
            Config config;
            try
            {
                var configXml = File.ReadAllText(configFileName);
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