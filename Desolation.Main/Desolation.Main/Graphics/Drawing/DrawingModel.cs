using System.Drawing;

namespace Desolation.Main.Graphics.Drawing
{
    public abstract class DrawingModel
    {
        public Color Color { get; set; }

        protected DrawingModel()
        { }

        protected DrawingModel(Color color)
        {
            Color = color;
        }

        public abstract void Draw();
    }
}