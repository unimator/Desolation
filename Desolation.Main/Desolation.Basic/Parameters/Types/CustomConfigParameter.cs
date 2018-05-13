namespace Desolation.Basic.Parameters.Types
{
    public sealed class CustomConfigParameter : ParameterBase
    {
        internal override int ArgumentsNumber => 1;
        internal override string Name => "config";

        public string ConfigFileName { get; set; }

        internal override void Parse(string[] arguments)
        {
            ConfigFileName = arguments[0];
        }

        public override bool Compare(ParameterBase other)
        {
            CustomConfigParameter customConfigParameter = other as CustomConfigParameter;

            if (ConfigFileName != customConfigParameter?.ConfigFileName) return false;
            return true;
        }
    }
}
