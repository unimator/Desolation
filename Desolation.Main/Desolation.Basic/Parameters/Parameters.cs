using Desolation.Basic.Collections;
using Desolation.Basic.Parameters.Types;

namespace Desolation.Basic.Parameters
{
    public class Parameters
    {
        public TypedSet<ParameterBase> ParametersSet { get; } = new TypedSet<ParameterBase>();

        internal Parameters() {}
    }
}
