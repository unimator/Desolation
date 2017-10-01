using System;
using System.Collections.Generic;
using Desolation.Basic.Parameters.Types;

namespace Desolation.Basic.Parameters.Factories
{
    public class DefaultArgumentsFactory : ArgumentsFactoryBase
    {
        public override Dictionary<string, Type> CreateParameters()
        {
            var parameters = new Dictionary<string, Type>
            {
                { "developer", typeof(DeveloperModeParameter) },
                { "resolution", typeof(ResolutionParamter) },
                { "config", typeof(CustomConfigParameter) }
            };

            return parameters;
        }
    }
}