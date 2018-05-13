using Desolation.Main.Graphics.Texture.TextureManagers;
using OpenTK;

namespace Desolation.Main.Graphics.Drawing.Drawing3D
{
    public class Tile3D : Rectangle3D
    {
        public Tile3D(Vector3 center, Vector3 normal, Vector3 up, float size)
            :
            this(center, normal, up, size, RectangleTextureManager.Default)
        { }

        public Tile3D(Vector3 center, Vector3 normal, Vector3 up, float size, RectangleTextureManager textureManager)
            :
            base(center, normal, up, size, size, textureManager)
        { }
    }
}