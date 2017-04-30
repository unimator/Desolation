using Desolation.General.ArgumentsParser;
using Desolation.General.ArgumentsParser.Arguments;
using NUnit.Framework;

namespace Desolation.Tests
{
    [TestFixture]
    public class ArgumentsParserTest
    {
        private static object[] _parametersCases =
        {
            new object [] {new string [] {"--developer"}, new Parameters() {DeveloperMode = new DeveloperModeParameter() {DeveloperModeOn = true}} }
        };
    }
}
