using System;
using System.Drawing;
using Desolation.Graphics.Graphics.DrawingContext.DrawingContext2D;
using Desolation.Graphics.Graphics.Texture;
using Desolation.Graphics.Graphics.Texture.TextureManagers;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Desolation.Graphics.Window
{
    public class MainWindow : GameWindow
    {
        public MainWindow(int width, int height) :
            base(width, height, GraphicsMode.Default, string.Empty, GameWindowFlags.Default, DisplayDevice.GetDisplay(DisplayIndex.Default))
        {

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, this.Width, this.Height);
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
            
            var clippingArea = new ClippingArea
            {
                Left = -1.0f,
                Right = 1.0f,
                Bottom = -1.0f,
                Top = 1.0f,
                Near = 1.0f,
                Far = -1.0f
            };

            var buttonPlaceholderTexture = new Texture2D(Images.placeholder_100x40);
            buttonPlaceholderTexture.InitTexture();
            var rectangle = new Graphics.Drawables.Drawables3D.Rectangle(Vector3.Zero, new Vector3(0, 0, 1), new Vector3(0, -1, 0), 0.1f, 0.04f);
            rectangle.TextureManager = new RectangleTextureManager(buttonPlaceholderTexture);
            
            var point = new Graphics.Drawables.Drawables2D.Point(new Vector2(0.0f, 0.0f), 5.0f, Color.Aqua);
            var dc2d = new DrawingContext2D(clippingArea);
            dc2d.Drawables.Add(point);
            dc2d.Drawables.Add(rectangle);

            dc2d.Render();

            SwapBuffers();

        }
    }
}
