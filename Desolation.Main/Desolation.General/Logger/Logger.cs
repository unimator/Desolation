using System.Text;

namespace Desolation.General.Logger
{
    public static class Logger
    {
        private static StringBuilder LoggerData { get; } = new StringBuilder();

        public static void LogMessage(string message)
        {
            LoggerData.Append(message);
        }

        public static string ReadLog()
        {
            return LoggerData.ToString();
        }
    }
}
