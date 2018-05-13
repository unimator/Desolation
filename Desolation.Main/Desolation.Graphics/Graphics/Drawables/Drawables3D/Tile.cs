using Desolation.Graphics.Graphics.Texture.TextureManagers;
using OpenTK;

namespace Desolation.Graphics.Graphics.Drawables.Drawables3D
{
    public class Tile : Rectangle
    {
        public Tile(Vector3 center, Vector3 normal, Vector3 up, float size)
            :
            this(center, normal, up, size, RectangleTextureManager.Default)
        { }

        public Tile(Vector3 center, Vector3 normal, Vector3 up, float size, RectangleTextureManager textureManager)
            :
            base(center, normal, up, size, size, textureManager)
        { }
    }
}