using System.Drawing;

namespace Desolation.Graphics.Graphics.Drawables
{
    public abstract class Drawable
    {
        public Color Color { get; set; }

        protected Drawable()
        { }

        protected Drawable(Color color)
        {
            Color = color;
        }

        public abstract void Draw();
    }
}