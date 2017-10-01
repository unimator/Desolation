using System;
using System.Collections.Generic;

namespace Desolation.Basic.Parameters.Factories
{
    public abstract class ArgumentsFactoryBase
    {
        public abstract Dictionary<string, Type> CreateParameters();
    }
}