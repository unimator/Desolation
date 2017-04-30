using System;
using System.Drawing;
using Desolation.Graphics.Graphics.Drawables;
using Desolation.Graphics.Graphics.DrawingContext;
using Desolation.Graphics.Graphics.DrawingContext.DrawingContext2D;
using Desolation.Graphics.Graphics.DrawingContext.DrawingContext3D;
using Desolation.Graphics.Graphics.Texture;
using Desolation.Graphics.Graphics.Texture.TextureManagers;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Point = Desolation.Graphics.Graphics.Drawables.Point;

namespace Desolation.Graphics.Window
{
    public class MainWindow : GameWindow
    {
        private Texture2D textureA;
        private Texture2D textureB;
        private Texture2D hello;
        private float f = 0.0f;

        public MainWindow(int width, int height) :
            base(width, height, GraphicsMode.Default, string.Empty, GameWindowFlags.Default, DisplayDevice.GetDisplay(DisplayIndex.Default))
        {
            GL.Viewport(0, 0, this.Width, this.Height);

            textureA = new Texture2D();
            textureA.LoadBitmap("a.png");
            textureA.LoadTexture();
            hello = new Texture2D();
            hello.LoadBitmap("hello.bmp");
            hello.MakeBitmapTransparent(Color.Fuchsia);
            hello.LoadTexture();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            textureA.Dispose();
            //textureB.Dispose();
            hello.Dispose();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);

            /*this.Location = new Point(0, 0);

            if (this.WindowState != WindowState.Fullscreen)
            {
                DisplayDevice.Default.ChangeResolution(1024, 768, 32, 60);
                this.WindowState = WindowState.Fullscreen;
            }

            else
            {Class1
                this.WindowState = WindowState.Normal;
                DisplayDevice.Default.RestoreResolution();
            }*/
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            
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

            Perspective perspective = new Perspective
            {
                AspectRatio = (float) this.Width / this.Height,
                FieldOfView = (float) Math.PI / 4,
                ZNear = 1,
                ZFar = 100,
                Eye = new Vector3(25f * (float) Math.Cos(f), 5, 25f * (float) Math.Sin(f)),
                Target = new Vector3(0, 0, 0),
                Up = new Vector3(0, 1, 0)
            };

            
            Vector3 center = new Vector3(1, 1, 1);
            Vector3 up = new Vector3(0, 25f , 2.0f);
            Vector3 normal = new Vector3(1, 0, 0);

            var dc3 = new DrawingContext3D(perspective);

            dc3.Drawables.Add(new Point(new Vector3(-8.5f, 2, -3), 5.0f, Color.Red));

            /*GL.Vertex3(-1.0, -1.0, 1.0);
            GL.Vertex3(-1.0, 1.0, 1.0);
            GL.Vertex3(1.0, 1.0, 1.0);
            GL.Vertex3(1.0, -1.0, 1.0);
            GL.Vertex3(-1.0, -1.0, -1.0);
            GL.Vertex3(-1.0, 1.0, -1.0);
            GL.Vertex3(1.0, 1.0, -1.0);
            GL.Vertex3(1.0, -1.0, -1.0);*/

            dc3.Drawables.Add(new Tile(new Vector3(2, -8, 2), normal, new Vector3(0, -1, -1), 5.0f, Color.FromArgb(128, 154, 210, 15)));
            dc3.Drawables.Add(new Tile(center, normal, up, 5.0f,  new RectangleTextureManager(hello)));
            dc3.Drawables.Add(new Tile(new Vector3(-3, -2, 1), normal, new Vector3(0, -1, -1), 5.0f, Color.FromArgb(255, 61, 146, 241)));
            dc3.Drawables.Add(new Tile(new Vector3(-8, -5, 4), normal, new Vector3(0, -1, -1), 5.0f, new RectangleTextureManager(Texture2D.None, Color.FromArgb(135, 16, 154, 84))));
            dc3.Drawables.Add(new Graphics.Drawables.Rectangle(new Vector3(-1, 2, 6), normal, new Vector3(0, -1, -1), 3.0f, 5.0f, Color.Sienna));
            var prism = new SquarePrism(new Vector3(1, 2, -3), normal, new Vector3(0, -1, -1), 3.0f, 4.0f, 2.0f,
                Color.Aqua);
            var faces = new Face[6];
            for (int i = 0; i < 6; ++i) faces[i] = prism.TextureManager.Faces[i];
            faces[(int) SquarePrismFaces.Front] = new Face(textureA, Color.White);
            faces[(int)SquarePrismFaces.Back] = new Face(hello, Color.White);
            prism.TextureManager.Faces = faces;
            dc3.Drawables.Add(prism);

            dc3.Render();

            GL.Enable(EnableCap.Texture2D);
            //GL.MultMatrix(ref camera);
            /*GL.Begin(PrimitiveType.Points);
            {
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
            }
            GL.End();*/
            //GL.Rotate(f/10, 0, 1.0f, 0);
            //GL.Rotate(-10, 0, 0, 1.0f);
            //GL.Rotate(f, 1, 0, 0);

            GL.Disable(EnableCap.Texture2D);
            
            f += 0.01f;
            SwapBuffers();

        }
    }
}
