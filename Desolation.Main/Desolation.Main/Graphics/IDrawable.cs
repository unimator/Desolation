using System.Collections.Generic;
using Desolation.Main.Graphics.Drawing;

namespace Desolation.Main.Graphics
{
    public interface IDrawable
    {
        IEnumerable<DrawingModel> GetDrawingModel();
    }
}