using OpenTK;

namespace Desolation.Main.Graphics.Drawing.Drawing2D
{
    public abstract class Polygon2D : DrawingModel
    {
        protected bool Initialized;

        private Vector2 _center;
        public Vector2 Center
        {
            get => _center;
            set
            {
                _center = value;
                Initialized = false;
            }
        }

        private float _rotation;
        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                Initialized = false;
            }
        }

        protected Polygon2D(Vector2 center, float rotation)
        {
            Center = center;
            Rotation = rotation;
            Initialized = false;
        }

        protected virtual void Initialize() { }
    }
}