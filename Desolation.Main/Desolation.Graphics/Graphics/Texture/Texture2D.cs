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
                //GL.BindTexture(TextureTarget.Texture2D, _noneInstance.Id.Value);
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
        
        private readonly Bitmap _bitmap;

        private Texture2D() { }

        public Texture2D(Bitmap bitmap)
        {
            if(bitmap == null)
                throw new ArgumentNullException(nameof(bitmap));

            _bitmap = (Bitmap)bitmap.Clone();
        }
        
        public void SetTransparentColor(Color color)
        {
            if(_bitmap == null)
                throw new ArgumentNullException(nameof(color));

            _bitmap.MakeTransparent(color);
        }

        public void Dispose()
        {
            if (Id.HasValue && GL.IsTexture(Id.Value))
            {
                GL.DeleteTexture(Id.Value);
            }
        }

        public override void BindTexture()
        {
            if(!Id.HasValue)
                throw new Exception("Texture has not been loaded to memory.");
            GL.BindTexture(TextureTarget.Texture2D, Id.Value);
        }

        public void InitTexture()
        {
            if (_bitmap == null)
                throw new ArgumentNullException("Bitmap has not been loaded.");

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
    }
}