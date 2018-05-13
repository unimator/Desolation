using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Desolation.Graphics.Graphics.Drawables.Drawables3D
{
    public class Point : Drawable
    {
        public Vector3 Coordinates { get; set; }
        public float Size { get; set; }
        
        public Point(Vector3 coordinates)
            :
            this(coordinates, 1.0f)
        { }

        public Point(Vector3 coordinates, float size)
            :
            this(coordinates, size, Color.White)
        { }

        public Point(Vector3 coordinates, float size, Color color)
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
            GL.Vertex3(Coordinates.X, Coordinates.Y, Coordinates.Z);
            GL.End();
            GL.Color3(Color.Transparent);
        }
    }
}