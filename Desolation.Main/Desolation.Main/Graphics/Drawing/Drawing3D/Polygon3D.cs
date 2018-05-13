using System;
using OpenTK;

namespace Desolation.Main.Graphics.Drawing.Drawing3D
{
    public abstract class Polygon3D : DrawingModel
    {
        public Vector3 Center { get; set; }
        public Vector3 Normal { get; set; }
        public Vector3 Up { get; set; }

        protected Polygon3D(Vector3 center, Vector3 normal, Vector3 up)
        {
            Center = center;
            Normal = normal;
            Up = up;
        }

        protected bool AreVectorsValid()
        {
            if (Math.Abs(Vector3.CalculateAngle(Normal, Up) - MathHelper.PiOver2) > 0.00001f)
                return false;
            return true;
        }
    }
}