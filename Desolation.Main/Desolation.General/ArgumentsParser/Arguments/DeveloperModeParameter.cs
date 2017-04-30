namespace Desolation.General.ArgumentsParser.Arguments
{
    public sealed class DeveloperModeParameter : ParameterBase
    {
        internal override int ArgumentsNumber => 0;
        internal override string Name => "developer";

        public bool DeveloperModeOn { get; set; }

        internal override void Parse(Parameters parameters, string[] arguments)
        {
            parameters.DeveloperMode = new DeveloperModeParameter {DeveloperModeOn = true};
        }
        
        public override bool Compare(ParameterBase other)
        {
            DeveloperModeParameter developerModeParameter = other as DeveloperModeParameter;

            if (DeveloperModeOn != developerModeParameter?.DeveloperModeOn) return false;

            return true;
        }
    }
}
