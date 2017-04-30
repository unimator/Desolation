using System.Drawing;
using Desolation.Graphics.Graphics.Texture;
using Desolation.Graphics.Graphics.Texture.TextureManagers;
using OpenTK;

namespace Desolation.Graphics.Graphics.Drawables
{
    public class Tile : Rectangle
    {
        public Tile(Vector3 center, Vector3 normal, Vector3 up, float size)
            :
            this(center, normal, up, size, Color.White)
        { }

        public Tile(Vector3 center, Vector3 normal, Vector3 up, float size, Texture2D texture)
            :
            this(center, normal, up, size, texture, Color.White)
        { }

        public Tile(Vector3 center, Vector3 normal, Vector3 up, float size, Color color)
            :
            this(center, normal, up, size, Texture2D.None, color)
        { }

        public Tile(Vector3 center, Vector3 normal, Vector3 up, float size, Texture2D texture, Color color)
            :
            this(center, normal, up, size, new RectangleTextureManager(texture, color))
        { }

        public Tile(Vector3 center, Vector3 normal, Vector3 up, float size, RectangleTextureManager textureManager)
            :
            base(center, normal, up, size, size, textureManager)
        { }
    }
}