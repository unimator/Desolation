using System;
using System.Drawing;
using Desolation.Main.Graphics.Texture;
using Desolation.Main.Graphics.Texture.TextureManagers;
using Desolation.Main.Window;
using OpenTK;

namespace Desolation.Main.Graphics.Drawing.Drawing2D
{
    public class Text2D : Rectangle2D
    {
        public string Text { get; set; }

        public Font Font { get; set; }

        public Color FontColor { get; set; }

        public float Opacity { get; set; }

        public Text2D(Vector2 center, float rotation, string text, Font font, Color fontColor, float opacity = 1.0f) : base(center, rotation, 0, 0)
        {
            Text = text;
            Font = font;
            FontColor = fontColor;

            if(opacity < 0.0f || opacity > 1.0f)
                throw new ArgumentException($"{nameof(opacity)} value should be between 0 and 1.");

            Opacity = opacity;
        }
        
        protected override void Initialize()
        {
            if (string.IsNullOrEmpty(Text) || Font == null)
                return;

            TextureManager = new RectangleTextureManager();
            using (var graphics = MainWindowUtils.GetGraphics())
            {
                var size = graphics.MeasureString(Text, Font);
                var bitmap = new Bitmap((int)size.Width, (int)size.Height);
                using (var gfx = System.Drawing.Graphics.FromImage(bitmap))
                using (var brush = new SolidBrush(FontColor))
                {
                    gfx.DrawString(Text, Font, brush, 0, 0);
                }
                var texture = new Texture2D(bitmap);
                texture.Initialize();
                TextureManager.Face = new Face(texture, Color.FromArgb((int)(Opacity * 255), Color.White));
                Height = size.Height;
                Width = size.Width;
            }

            base.Initialize();
            Initialized = true;
        }
    }
}