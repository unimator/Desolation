using System;
using Desolation.Main.Graphics.Texture.TextureManagers;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Desolation.Main.Graphics.Drawing.Drawing2D
{
    public class Rectangle2D : Polygon2D
    {
        private float _width;
        public float Width
        {
            get => _width;
            set
            {
                _width = value;
                Initialized = false;
            }
        }

        private float _height;
        public float Height
        {
            get => _height;
            set
            {
                _height = value;
                Initialized = false;
            }
        }

        public RectangleTextureManager TextureManager { get; set; }

        public Vector2 VertexTopLeft { get; private set; }
        public Vector2 VertexTopRight { get; private set; }
        public Vector2 VertexBottomLeft { get; private set; }
        public Vector2 VertexBottomRight { get; private set; }

        public Rectangle2D(Vector2 center, float rotation, float width, float height)
            :
            this(center, rotation, width, height, RectangleTextureManager.Default)
        { }

        public Rectangle2D(Vector2 center, float rotation, float width, float height, RectangleTextureManager textureManager)
            : base(center, rotation)
        {
            Width = width;
            Height = height;
            TextureManager = textureManager;
        }

        public override void Draw()
        {
            if (!Initialized)
                Initialize();

            GL.Color4(TextureManager.Face.Color);
            GL.Enable(EnableCap.Texture2D);
            TextureManager.Face.Texture?.BindTexture();
            GL.Begin(PrimitiveType.Polygon);
            {
                GL.TexCoord2(0, 1);
                GL.Vertex2(VertexBottomLeft);
                GL.TexCoord2(0, 0);
                GL.Vertex2(VertexTopLeft);
                GL.TexCoord2(1, 0);
                GL.Vertex2(VertexTopRight);
                GL.TexCoord2(1, 1);
                GL.Vertex2(VertexBottomRight);
            }
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Color4(Color.Transparent);
        }

        protected override void Initialize()
        {
            var sin = (float) Math.Sin(MathHelper.DegreesToRadians(Rotation));
            var cos = (float) Math.Cos(MathHelper.DegreesToRadians(Rotation));

            var x1 = cos * Width - sin * Height;
            var y1 = sin * Width + cos * Height;
            var x2 = cos * -Width - sin * Height;
            var y2 = sin * -Width + cos * Height;

            VertexTopLeft = Center + new Vector2(x2, y2);
            VertexBottomLeft = Center + new Vector2(-x1, -y1);
            VertexBottomRight = Center + new Vector2(-x2, -y2);
            VertexTopRight = Center + new Vector2(x1, y1);

            base.Initialize();
            Initialized = true;
        }
    }
}