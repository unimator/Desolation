namespace Desolation.Basic.Parameters.Types
{
    public sealed class ResolutionParamter : ParameterBase
    {
        internal override int ArgumentsNumber => 2;
        internal override string Name => "resolution";

        public int Width { get; set; }
        public int Height { get; set; }
        
        internal override ParameterBase Parse(string[] arguments)
        {
            var resolution = new ResolutionParamter
            {
                Width = int.Parse(arguments[0]),
                Height = int.Parse(arguments[1])
            };
            return resolution;
        }

        public override bool Compare(ParameterBase other)
        {
            if (!(other is ResolutionParamter)) return false;

            ResolutionParamter resolutionParamter = (ResolutionParamter) other;

            if (this.Height != resolutionParamter.Height) return false;
            else if (this.Width != resolutionParamter.Width) return false;
            return true;
        }

        public override void TryApplyOnConfig(Config.Config config)
        {
            config.WindowSettings.Width = Width;
            config.WindowSettings.Height = Height;
        }
    }
}
