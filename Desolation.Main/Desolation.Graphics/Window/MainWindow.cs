using System.Drawing;
using Desolation.Graphics.Graphics.DrawingContext.DrawingContext2D;
using Desolation.Graphics.Graphics.Texture;
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

            var txt = new Texture2D();
            txt.LoadBitmap("a.png");

            var clippingArea = new ClippingArea
            {
                Left = -1.0f,
                Right = 1.0f,
                Bottom = -1.0f,
                Top = 1.0f,
                Near = 1.0f,
                Far = -1.0f
            };

            var dc2d = new DrawingContext2D(clippingArea);

            dc2d.Render();

            SwapBuffers();

        }
    }
}
