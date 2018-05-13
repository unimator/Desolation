using System.Collections.Generic;

namespace Desolation.Main.Graphics.DrawingContext
{
    public abstract class DrawingContext
    {
        public ICollection<IDrawable> Drawables { get; } = new List<IDrawable>();

        public abstract void Render();
    }
}
