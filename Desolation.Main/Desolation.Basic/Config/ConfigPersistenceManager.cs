using System.IO;
using Desolation.Basic.Helpers;

namespace Desolation.Basic.Config
{
    public static class ConfigPersistenceManager
    {
        public static void SaveToFile(Config config, string fileName)
        {
            var xml = XmlHelper.ToXml(config);
            using (var streamWriter = File.CreateText(fileName))
            {
                streamWriter.Write(xml);
            }
        }
    }
}