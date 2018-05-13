﻿using System;
using System.Drawing;
using Desolation.Main.Graphics.Texture.TextureManagers;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Desolation.Main.Graphics.Drawing.Drawing3D
{
    public class Rectangle3D : Polygon3D
    {
        public float SizeW { get; set; }
        public float SizeH { get; set; }
        public RectangleTextureManager TextureManager { get; set; }

        public Vector3 VertexTopLeft { get; private set; }
        public Vector3 VertexTopRight { get; private set; }
        public Vector3 VertexBottomLeft { get; private set; }
        public Vector3 VertexBottomRight { get; private set; }

        public Rectangle3D(Vector3 center, Vector3 normal, Vector3 up, float sizeW, float sizeH)
            :
            this(center, normal, up, sizeW, sizeH, RectangleTextureManager.Default)
        { }
        
        public Rectangle3D(Vector3 center, Vector3 normal, Vector3 up, float sizeW, float sizeH, RectangleTextureManager textureManager)
            :
            base(center, normal, up)
        {
            SizeW = sizeW;
            SizeH = sizeH;
            TextureManager = textureManager;
            RecalculateVertices();
        }

        public override void Draw()
        {
            GL.Color4(TextureManager.Face.Color);
            GL.Enable(EnableCap.Texture2D);
            TextureManager.Face.Texture?.BindTexture();
            GL.Begin(PrimitiveType.Polygon);
            {
                GL.TexCoord2(1, 1);
                GL.Vertex3(VertexTopLeft);
                GL.TexCoord2(1, 0);
                GL.Vertex3(VertexBottomLeft);
                GL.TexCoord2(0, 0);
                GL.Vertex3(VertexBottomRight);
                GL.TexCoord2(0, 1);
                GL.Vertex3(VertexTopRight);
            }
            GL.End();
            GL.Disable(EnableCap.Texture2D);
            GL.Color4(Color.Transparent);
        }

        private void RecalculateVertices()
        {
            if(!AreVectorsValid())
                throw new ArithmeticException("Vectors normal and up are not orthogonal");

            var upNormalized = Vector3.Normalize(Up);
            var normalNormalized = Vector3.Normalize(Normal);
            var ortho = Vector3.Cross(normalNormalized, upNormalized);

            VertexTopLeft = SizeW * ortho + SizeH * upNormalized + Center;
            VertexBottomLeft = SizeW * ortho - SizeH * upNormalized + Center;
            VertexBottomRight = SizeW * -ortho - SizeH * upNormalized + Center;
            VertexTopRight = SizeW * -ortho + SizeH * upNormalized + Center;
        }
    }
}