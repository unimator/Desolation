namespace Desolation.Basic.Parameters.Types
{
    public sealed class DeveloperModeParameter : ParameterBase
    {
        internal override int ArgumentsNumber => 0;
        internal override string Name => "developer";

        public bool DeveloperModeOn { get; set; }

        internal override void Parse(string[] arguments)
        {
            DeveloperModeOn = true;
        }
        
        public override bool Compare(ParameterBase other)
        {
            var developerModeParameter = other as DeveloperModeParameter;

            if (DeveloperModeOn != developerModeParameter?.DeveloperModeOn) return false;

            return true;
        }
    }
}
