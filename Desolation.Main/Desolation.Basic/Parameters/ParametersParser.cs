using System;
using System.Collections.Generic;
using System.Linq;
using Desolation.Basic.Parameters.Factories;
using Desolation.Basic.Parameters.Types;

namespace Desolation.Basic.Parameters
{
    public class ArgumentsParser
    {
        private readonly Dictionary<string, Type> _parametersTypes;

        public ArgumentsParser(IArgumentsFactory argumentsFactory)
        {
            _parametersTypes = argumentsFactory.CreateParameters();
        }

        public Parameters Parse(string [] argumentsLine)
        {
            Parameters parameters = new Parameters();

            for(int i = 0; i < argumentsLine.Length; ++i)
            {
                if (argumentsLine[i].StartsWith(ParameterBase.ParameterPrefix) == false)
                    throw new ArgumentException($"{argumentsLine[i]} is not a valid parameter (should start with {ParameterBase.ParameterPrefix})");

                string parameter = argumentsLine[i].Substring(ParameterBase.ParameterPrefix.Length);
            
                if (_parametersTypes.ContainsKey(parameter))
                {
                    var argument = (ParameterBase) Activator.CreateInstance(_parametersTypes[parameter]);
                    
                    int argumentsNumber = argument.ArgumentsNumber;

                    if(argumentsLine.Length <= i + argumentsNumber)
                        throw new ArgumentException($"Parameter {argumentsLine[i]} requires {argumentsNumber} arguments, {argumentsLine.Length - i - 1} provided");

                    if (argumentsNumber == -1)
                    {
                        argumentsNumber = 1;
                        while (argumentsLine.Length < i + argumentsNumber &&
                               argumentsLine[i + argumentsNumber].StartsWith(ParameterBase.ParameterPrefix) == false) ++argumentsNumber;
                    }

                    string[] argumentParameters = argumentsLine.Skip(i + 1).Take(argumentsNumber).ToArray();
                    argument.Parse(argumentParameters);
                    parameters.ParametersSet.Insert(argument);

                    i += argumentsNumber;
                } else 
                    throw new ArgumentException($"Unknown parameter {argumentsLine[i]}");
            }

            return parameters;
        }
    }
}
