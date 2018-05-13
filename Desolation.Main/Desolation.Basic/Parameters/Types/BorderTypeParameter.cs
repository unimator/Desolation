using Desolation.Basic.Config.Options;

namespace Desolation.Basic.Parameters.Types
{
    public class BorderTypeParameter : ParameterBase
    {
        internal override int ArgumentsNumber => 1;
        internal override string Name => "border";

        public WindowFeatures.BorderType BorderType;

        internal override void Parse(string[] arguments)
        {
            var border = arguments[0];
            if (string.CompareOrdinal(border, Resources.NormalBorder) == 0)
            {
                BorderType = WindowFeatures.BorderType.Normal;
            }
            else if (string.CompareOrdinal(border, Resources.NoBorder) == 0)
            {
                BorderType = WindowFeatures.BorderType.Borderless;
            }
            else if (string.CompareOrdinal(border, Resources.FullscreenBorder) == 0)
            {
                BorderType = WindowFeatures.BorderType.Fullscreen;
            }
        }

        public override bool Compare(ParameterBase other)
        {
            var borderTypeParameter = other as BorderTypeParameter;

            if (BorderType != borderTypeParameter?.BorderType) return false;
            return true;
        }

        public override void TryApplyOnConfig(Config.Config config)
        {
            config.WindowSettings.BorderType = BorderType;
        }
    }
}