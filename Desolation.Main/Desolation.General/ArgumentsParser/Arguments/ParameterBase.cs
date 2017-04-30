using System;

namespace Desolation.General.ArgumentsParser.Arguments
{
    [Serializable]
    public abstract class ParameterBase
    {
        /// <summary>
        /// Prefix leading actual parameter name.
        /// </summary>
        internal static string ParameterPrefix = "--";

        /// <summary>
        /// Number of arguments which parameter is taking.
        /// </summary>
        internal abstract int ArgumentsNumber { get; }
        
        /// <summary>
        /// Name of the parameter.
        /// </summary>
        internal abstract string Name { get; }

        internal abstract void Parse(Parameters parameters, string [] arguments);

        /// <summary>
        /// Compares two parameters.
        /// </summary>
        /// <param name="other">Parameter to compare.</param>
        /// <returns>Returns true if parameters are equal, false otherwise.</returns>
        public abstract bool Compare(ParameterBase other);
    }
}
