using System;
using System.Collections.Generic;

namespace Desolation.Basic.Parameters.Factories
{
    public interface IArgumentsFactory
    {
        Dictionary<string, Type> CreateParameters();
    }
}