using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using OpenTK.Graphics.OpenGL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace Desolation.Graphics.Graphics.Texture
{
    public class Texture2D : Texture, IDisposable
    {
        private static Texture2D _noneInstance;

        public static Texture2D None
        {
            get
            {
                if (_noneInstance != null)
                    return _noneInstance;

                _noneInstance = new Texture2D();
                _noneInstance.Id = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, _noneInstance.Id.Value);
                return _noneInstance;
            }
        }
        
        private float _opacity;
        public float Opacity {
            get
            {
                return _opacity;
            }
            set
            {
                if(value < 0.0f || value > 1.0f)
                    throw new ArgumentException("Opacity value should be between 0 and 1.");
                _opacity = value;
            }
        }
        public int Width { get; private set; }
        public int Heigth { get; private set; }
        
        private Bitmap _bitmap;

        public void LoadBitmap(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"{path} not found.");

            _bitmap = new Bitmap(path);
        }

        public void UnloadBitmap()
        {
            _bitmap.Dispose();
        }

        public void MakeBitmapTransparent(Color color)
        {
            if(_bitmap == null)
                throw new ArgumentNullException("Bitmap has not been loaded.");

            _bitmap.MakeTransparent(color);
        }

        public void Dispose()
        {
            UnloadTexture();
            Width = Heigth = 0;
        }

        public override void BindTexture()
        {
            if(!Id.HasValue)
                throw new Exception("Texture has not been loaded to memory.");
            GL.BindTexture(TextureTarget.Texture2D, Id.Value);
        }

        public void LoadTexture()
        {
            if (_bitmap == null)
                throw new ArgumentNullException("Bitmap has not been loaded.");

            if (Id.HasValue)
                UnloadTexture();

            Id = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, Id.Value);
            
            BitmapData bitmapData = _bitmap.LockBits(new Rectangle(0, 0, _bitmap.Width, _bitmap.Height), ImageLockMode.ReadOnly,
               PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _bitmap.Width, _bitmap.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bitmapData.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Clamp);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Clamp);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            Width = _bitmap.Width;
            Heigth = _bitmap.Height;

            _bitmap.UnlockBits(bitmapData);
        }

        public void UnloadTexture()
        {
            if (Id.HasValue && GL.IsTexture(Id.Value))
            {
                GL.DeleteTexture(Id.Value);
            }
        }

        private Bitmap SetOpacity(Bitmap bitmap, float opacity)
        {
            Bitmap canvas = new Bitmap(bitmap.Width, bitmap.Height);
            using (System.Drawing.Graphics gfx = System.Drawing.Graphics.FromImage(canvas))
            {
                gfx.DrawImage(bitmap, 0, 0);
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;

                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                
                gfx.DrawImage(bitmap, new Rectangle(0, 0, canvas.Width, canvas.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
            }
            return bitmap;
        }
    }
}