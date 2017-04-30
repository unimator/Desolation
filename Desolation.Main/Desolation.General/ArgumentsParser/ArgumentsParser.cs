using System;
using System.Collections.Generic;
using System.Linq;
using Desolation.General.ArgumentsParser.Arguments;

namespace Desolation.General.ArgumentsParser
{
    public static class ArgumentsParser
    {
        private static readonly Dictionary<string, Type> ArgumentsTypes = new Dictionary<string, Type>()
        {
            { "developer", typeof(DeveloperModeParameter) },
            { "resolution", typeof(ResolutionParamter) },
            { "config", typeof(CustomConfigParameter) }
        };

        public static Parameters Parse(string [] arguments)
        {
            Parameters parameters = new Parameters();

            for(int i = 0; i < arguments.Length; ++i)
            {
                if (arguments[i].StartsWith(ParameterBase.ParameterPrefix) == false)
                    throw new ArgumentException($"{arguments[i]} is not a valid parameter (should start with {ParameterBase.ParameterPrefix})");

                string parameter = arguments[i].Substring(ParameterBase.ParameterPrefix.Length);
            
                if (ArgumentsTypes.ContainsKey(parameter))
                {
                    ParameterBase argument = (ParameterBase) Activator.CreateInstance(ArgumentsTypes[parameter]);
                    
                    int argumentsNumber = argument.ArgumentsNumber;

                    if(arguments.Length <= i + argumentsNumber)
                        throw new ArgumentException($"Parameter {arguments[i]} requires {argumentsNumber} arguments, {arguments.Length - i - 1} provided");

                    if (argumentsNumber == -1)
                    {
                        argumentsNumber = 1;
                        while (arguments.Length < i + argumentsNumber &&
                               arguments[i + argumentsNumber].StartsWith(ParameterBase.ParameterPrefix) == false) ++argumentsNumber;
                    }

                    string[] argumentParameters = arguments.Skip(i + 1).Take(argumentsNumber).ToArray();
                    argument.Parse(parameters, argumentParameters);

                    i += argumentsNumber;
                } else 
                    throw new ArgumentException($"Unknown parameter {arguments[i]}");
            }

            return parameters;
        }
    }
}
