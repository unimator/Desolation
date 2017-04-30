using System.Drawing;

namespace Desolation.Graphics.Graphics.Texture
{
    public struct Face
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }

        public Face(Texture2D texture, Color color)
        {
            Texture = texture;
            Color = color;
        }
    }
}