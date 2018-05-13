using System;
using System.Drawing;
using Desolation.Basic.Config.Options;
using Desolation.Basic.Config.Options.Entities;
using Desolation.Graphics;
using Desolation.Main.Graphics.Drawing.Drawing2D;
using Desolation.Main.Graphics.DrawingContext.DrawingContext2D;
using Desolation.Main.Graphics.Texture;
using Desolation.Main.Graphics.Texture.TextureManagers;
using Desolation.Main.GUI;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Desolation.Main.Window
{
    public class MainWindow : GameWindow
    {
        private DrawingContext2D _drawingContext2D;
        private Rectangle2D _rectangle;
        private readonly float _aspectRatio = 16.0f / 9.0f;
        private float _clippingAreaWidth;
        private float _clippingAreaHeight;
        private float opacity;

        public MainWindow(WindowSettingsOption windowSettings) :
            base(windowSettings.Width, windowSettings.Height, GraphicsMode.Default, string.Empty, GameWindowFlags.Default, DisplayDevice.GetDisplay(DisplayIndex.Default))
        {
            var clippingArea = GetClippingArea();
            _clippingAreaWidth = Math.Abs(clippingArea.Right - clippingArea.Left);
            _clippingAreaHeight = Math.Abs(clippingArea.Bottom - clippingArea.Top);
            _drawingContext2D = new DrawingContext2D(clippingArea);
            
            var buttonPlaceholderTexture = new Texture2D(Images.placeholder_100x40);
            buttonPlaceholderTexture.Initialize();
            //var rectangle = new Rectangle3D(Vector3.Zero, new Vector3(0, 0, 1), new Vector3(0, -1, 0), 0.1f, 0.04f);
            _rectangle = new Rectangle2D(new Vector2(-_clippingAreaWidth / 2, -_clippingAreaHeight / 2), 0.0f, 60.0f, 20.0f);
            _rectangle.TextureManager = new RectangleTextureManager(buttonPlaceholderTexture);

            var point = new Point2D(new Vector2(0.0f, 0.0f), 5.0f, Color.Aqua);
            opacity = 0.0f;

            switch (windowSettings.BorderType)
            {
                case WindowFeatures.BorderType.Normal:
                    WindowBorder = WindowBorder.Resizable;
                    break;
                case WindowFeatures.BorderType.Borderless:
                    WindowBorder = WindowBorder.Hidden;
                    break;
                case WindowFeatures.BorderType.Fullscreen:
                    WindowState = WindowState.Fullscreen;
                    break;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            var clippingArea = GetClippingArea();
            _clippingAreaWidth = Math.Abs(clippingArea.Right - clippingArea.Left);
            _clippingAreaHeight = Math.Abs(clippingArea.Bottom - clippingArea.Top);
            _drawingContext2D.ClippingArea = clippingArea;

            if ((int)_clippingAreaWidth == Width)
            {
                GL.Viewport(0, (Height - (int)_clippingAreaHeight) / 2, (int)_clippingAreaWidth, (int)_clippingAreaHeight);
            }
            else
            {
                GL.Viewport((Width - (int)_clippingAreaWidth) / 2, 0, (int)_clippingAreaWidth, (int)_clippingAreaHeight);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
   
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.Black);

            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.AlphaTest);
            GL.Enable(EnableCap.Blend);
            GL.Enable(EnableCap.SampleAlphaToCoverage);
            GL.AlphaFunc(AlphaFunction.Greater, 0.1f);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);


            _drawingContext2D.Drawables.Clear();

            var text = new Text2D(Vector2.Zero, 0.0f, "Ala ma kota", new Font("Arial", 10.0f), Color.DeepSkyBlue, opacity);

            opacity += 2.0f / 60.0f;
            if (opacity > 1.0f)
                opacity = 0.0f;
            var button = new Button(text);
            
            _drawingContext2D.Drawables.Add(button);
            _drawingContext2D.Render();

            SwapBuffers();
        }

        private ClippingArea GetClippingArea()
        {
            var windowRatio = (float) Width / Height;
            int height, width;

            if (windowRatio > _aspectRatio)
            {
                height = Height;
                width = (int) (_aspectRatio * height);
            }
            else
            {
                width = Width;
                height = (int) (1.0f / _aspectRatio * width);
            }

            return new ClippingArea
            {
                Left = -1.0f * width / 2,
                Right = 1.0f * width / 2,
                Bottom = -1.0f * height / 2,
                Top = 1.0f * height / 2,
                Near = 1.0f,
                Far = -1.0f
            };
        }
    }
}
