namespace Desolation.Basic.Parameters.Types
{
    public sealed class ResolutionParamter : ParameterBase
    {
        internal override int ArgumentsNumber => 2;
        internal override string Name => "resolution";

        public int Width { get; set; }
        public int Height { get; set; }
        
        internal override void Parse(string[] arguments)
        {
            Width = int.Parse(arguments[0]);
            Height = int.Parse(arguments[1]);
        }

        public override bool Compare(ParameterBase other)
        {
            if (!(other is ResolutionParamter)) return false;

            var resolutionParamter = (ResolutionParamter) other;

            if (Height != resolutionParamter.Height) return false;
            if (Width != resolutionParamter.Width) return false;
            return true;
        }

        public override void TryApplyOnConfig(Config.Config config)
        {
            config.WindowSettings.Width = Width;
            config.WindowSettings.Height = Height;
        }
    }
}
