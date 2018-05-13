using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Desolation.Main.Graphics.Drawing.Drawing2D
{
    public class Point2D : DrawingModel
    {
        public Vector2 Coordinates { get; set; }
        public float Size { get; set; }
       
        public Point2D(Vector2 coordinates)
            :
            this(coordinates, 1.0f)
        { }

        public Point2D(Vector2 coordinates, float size)
            :
            this(coordinates, size, Color.White)
        { }

        public Point2D(Vector2 coordinates, float size, Color color)
        {
            Coordinates = coordinates;
            Size = size;
            Color = color;
        }

        public override void Draw()
        {
            GL.PointSize(Size);
            GL.Color3(Color);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(Coordinates.X, Coordinates.Y);
            GL.End();
            GL.Color3(Color.Transparent);
        }
    }
}