using System.Collections.Generic;
using Desolation.Graphics.Graphics.Drawables;

namespace Desolation.Graphics.Graphics.DrawingContext
{
    public abstract class DrawingContext
    {
        public ICollection<Drawable> Drawables { get; private set; } = new List<Drawable>();

        public abstract void Render();
    }
}
