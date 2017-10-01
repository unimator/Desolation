using System.IO;
using System.Xml.Serialization;

namespace Desolation.Basic.Helpers
{
    public class XmlHelper
    {
        public static string ToXml<T>(T serializable)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, serializable);
                return stringWriter.ToString();
            }
        }

        public static T FromXml<T>(string serializable)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringReader stringReader = new StringReader(serializable))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}