using System.Drawing;
using Desolation.Graphics.Graphics.Texture.TextureManagers;

namespace Desolation.Main.Graphics.Texture.TextureManagers
{
    public class RectangleTextureManager : PolygonTextureManager
    {
        private static RectangleTextureManager _defaultInstance;

        public static RectangleTextureManager Default => _defaultInstance ?? (_defaultInstance = new RectangleTextureManager());

        public Face Face { get; set; }

        public RectangleTextureManager()
            :
            this(Texture2D.None)
        { }

        public RectangleTextureManager(Texture2D texture)
            :
            this(texture, Color.White)
        { }

        public RectangleTextureManager(Texture2D texture, Color color)
        {
            Face = new Face()
            {
                Color = color,
                Texture = texture
            };
        }
    }
}