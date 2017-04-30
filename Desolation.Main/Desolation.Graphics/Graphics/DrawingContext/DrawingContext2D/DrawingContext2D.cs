using OpenTK.Graphics.OpenGL;

namespace Desolation.Graphics.Graphics.DrawingContext.DrawingContext2D
{
    public sealed class DrawingContext2D : DrawingContext
    {
        public ClippingArea ClippingArea { get; }

        public DrawingContext2D(ClippingArea clippingArea)
        {
            ClippingArea = clippingArea;
        }

        public DrawingContext2D(
            float left, float rigth,
            float bottom, float top)
            :
            this(left, rigth, bottom, top, -1, 1)
        { }

        public DrawingContext2D(
            float left, float rigth,
            float bottom, float top,
            float near, float far)
            :
            this(new ClippingArea()
            {
                Left = left,
                Right = rigth,
                Bottom =  bottom,
                Top = top,
                Near = near,
                Far = far
            })
        { }
        
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
                drawable.Draw();
            }
            GL.PopMatrix();
        }
    }
}
