using OpenTK.Graphics.OpenGL;

namespace Desolation.Main.Graphics.DrawingContext.DrawingContext2D
{
    public sealed class DrawingContext2D : DrawingContext
    {
        public ClippingArea ClippingArea { get; set; }

        public DrawingContext2D(ClippingArea clippingArea)
        {
            ClippingArea = clippingArea;
        }

        public override void Render()
        {
            GL.PushMatrix();
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(ClippingArea.Left, ClippingArea.Right,
                ClippingArea.Bottom, ClippingArea.Top,
                ClippingArea.Near, ClippingArea.Far);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            foreach (var drawable in Drawables)
            {
                foreach (var drawingModel in drawable.GetDrawingModel())
                {
                    drawingModel.Draw();
                }
            }
            GL.PopMatrix();
        }
    }
}
