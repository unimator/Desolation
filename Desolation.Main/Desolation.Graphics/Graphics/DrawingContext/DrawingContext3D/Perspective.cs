using OpenTK;

namespace Desolation.Graphics.Graphics.DrawingContext.DrawingContext3D
{
    public struct Perspective
    {
        public float FieldOfView { get; set; }
        public float AspectRatio { get; set; }
        public float ZNear { get; set; }
        public float ZFar { get; set; }

        public Vector3 Eye { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 Up { get; set; }
    }
}