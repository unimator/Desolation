using System;
using System.Collections.Generic;
using Desolation.Basic.Parameters.Types;

namespace Desolation.Basic.Parameters.Factories
{
    public class DefaultArgumentsFactory : IArgumentsFactory
    {
        public Dictionary<string, Type> CreateParameters()
        {
            var parameters = new Dictionary<string, Type>
            {
                { "developer", typeof(DeveloperModeParameter) },
                { "resolution", typeof(ResolutionParamter) },
                { "config", typeof(CustomConfigParameter) },
                { "border", typeof(BorderTypeParameter) }
            };

            return parameters;
        }
    }
}