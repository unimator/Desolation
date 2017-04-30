using System;
using System.Collections.Generic;
using System.Drawing;
using Desolation.Graphics.Graphics.Texture;
using Desolation.Graphics.Graphics.Texture.TextureManagers;
using OpenTK;

namespace Desolation.Graphics.Graphics.Drawables
{
    public class SquarePrism : Polygon
    {
        public float SizeW { get; set; }
        public float SizeH { get; set; }
        public float SizeD { get; set; }
        public SquarePrismTextureManager TextureManager { get; set; }

        public Rectangle[] Rectangles { get; private set; }

        public SquarePrism(Vector3 center, Vector3 normal, Vector3 up, float sizeW, float sizeH, float sizeD)
            :
            this(center, normal, up, sizeW, sizeH, sizeD, Color.White)
        { }
        
        public SquarePrism(Vector3 center, Vector3 normal, Vector3 up, float sizeW, float sizeH, float sizeD, Color color)
            :
            this(center, normal, up, sizeW, sizeH, sizeD, new SquarePrismTextureManager(Texture2D.None, color))
        { }

        public SquarePrism(Vector3 center, Vector3 normal, Vector3 up, float sizeW, float sizeH, float sizeD, Texture2D texture)
            :
            this(center, normal, up, sizeW, sizeH, sizeD, new SquarePrismTextureManager(texture, System.Drawing.Color.White))
        { }

        public SquarePrism(Vector3 center, Vector3 normal, Vector3 up, float sizeW, float sizeH, float sizeD, Color color, Texture2D texture)
            :
            this(center, normal, up, sizeW, sizeH, sizeD, new SquarePrismTextureManager(texture, color))
        { }

        public SquarePrism(Vector3 center, Vector3 normal, Vector3 up, float sizeW, float sizeH, float sizeD, SquarePrismTextureManager textureManager)
            :
            base(center, normal, up)
        {
            SizeW = sizeW;
            SizeH = sizeH;
            SizeD = sizeD;
            TextureManager = textureManager;
            TextureManager.FacesChanged += TextureManagerOnFacesChanged;
            RecalculateVertices();
        }

        private void TextureManagerOnFacesChanged(object o, FacesChangedEventArgs args)
        {
            foreach (var face in args.FacesChanged)
            {
                Rectangles[(int)face].TextureManager.Face = TextureManager.Faces[(int) face];
            }
        }

        public override void Draw()
        {
            foreach(var rectangle in Rectangles)
                rectangle.Draw();
        }
        
        public sealed override void RecalculateVertices()
        {
            if (!AreVectorsValid())
                throw new ArithmeticException("Vectors normal and up are not orthogonal");

            if (Rectangles == null)
            {
                Rectangles = new Rectangle[Enum.GetValues(typeof(SquarePrismFaces)).Length];
                for (int i = 0; i < Enum.GetValues(typeof(SquarePrismFaces)).Length; ++i)
                    Rectangles[i] = new Rectangle(Center, Normal, Up, 1, 1, Texture2D.None, Color.White);
            }

            Vector3 upNormalized = Vector3.Normalize(Up);
            Vector3 normalNormalized = Vector3.Normalize(Normal);
            Vector3 ortho = Vector3.Cross(normalNormalized, upNormalized);

            SetupFace(Rectangles[(int)SquarePrismFaces.Front], Center, normalNormalized, upNormalized, SizeW, SizeH, SizeD);
            SetupFace(Rectangles[(int)SquarePrismFaces.Back], Center, -normalNormalized, upNormalized, SizeW, SizeH, SizeD);
            SetupFace(Rectangles[(int)SquarePrismFaces.Right], Center, ortho, upNormalized, SizeD, SizeH, SizeW);
            SetupFace(Rectangles[(int)SquarePrismFaces.Left], Center, -ortho, upNormalized, SizeD, SizeH, SizeW);
            SetupFace(Rectangles[(int)SquarePrismFaces.Bottom], Center, upNormalized, normalNormalized, SizeW, SizeD, SizeH);
            SetupFace(Rectangles[(int)SquarePrismFaces.Up], Center, -upNormalized, normalNormalized, SizeW, SizeD, SizeH);
        }

        private void SetupFace(Rectangle rectangle, Vector3 center, Vector3 normal, Vector3 up, float sizeX, float sizeY, float sizeZ)
        {
            rectangle.SizeH = sizeY;
            rectangle.SizeW = sizeX;
            rectangle.Center = center + normal * sizeZ;
            rectangle.Normal = normal;
            rectangle.Up = up;
            rectangle.RecalculateVertices();
        }
    }

    public enum SquarePrismFaces
    {
        Up = 0,
        Bottom = 1,
        Back = 2,
        Front = 3,
        Left = 4,
        Right = 5
    }
}