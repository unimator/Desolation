using Desolation.Graphics.Graphics.DrawingContext.DrawingContext3D;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Desolation.Main.Graphics.DrawingContext.DrawingContext3D
{
    public sealed class DrawingContext3D : DrawingContext
    {
        public Perspective Perspective { get; }

        public DrawingContext3D(Perspective perspective)
        {
            Perspective = perspective;
            Render();
        }

        private void BeforeRender()
        {
            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(Perspective.FieldOfView, Perspective.AspectRatio, Perspective.ZNear, Perspective.ZFar);
            GL.LoadMatrix(ref perspective);
            Matrix4 camera = Matrix4.LookAt(Perspective.Eye, Perspective.Target, Perspective.Up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref camera);
        }

        private void AfterRender()
        {
            GL.PopMatrix();
        }

        public override void Render()
        {
            BeforeRender();

            GL.Disable(EnableCap.CullFace);
            GL.DepthFunc(DepthFunction.Always);
            foreach (var drawable in Drawables)
            {
                foreach (var drawingModel in drawable.GetDrawingModel())
                {
                    drawingModel.Draw();
                }
            }
            GL.Disable(EnableCap.CullFace);
            GL.DepthFunc(DepthFunction.Lequal);
            foreach (var drawable in Drawables)
            {
                foreach (var drawingModel in drawable.GetDrawingModel())
                {
                    drawingModel.Draw();
                }
            }
            AfterRender();
        }
    }
}