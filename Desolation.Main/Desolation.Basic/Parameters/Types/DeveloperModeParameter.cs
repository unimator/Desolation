namespace Desolation.Basic.Parameters.Types
{
    public sealed class DeveloperModeParameter : ParameterBase
    {
        internal override int ArgumentsNumber => 0;
        internal override string Name => "developer";

        public bool DeveloperModeOn { get; set; }

        internal override ParameterBase Parse(string[] arguments)
        {
            var develeopeMode = new DeveloperModeParameter {DeveloperModeOn = true};
            return develeopeMode;
        }
        
        public override bool Compare(ParameterBase other)
        {
            DeveloperModeParameter developerModeParameter = other as DeveloperModeParameter;

            if (DeveloperModeOn != developerModeParameter?.DeveloperModeOn) return false;

            return true;
        }
    }
}
