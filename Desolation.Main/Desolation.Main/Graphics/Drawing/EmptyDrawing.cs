namespace Desolation.Main.Graphics.Drawing
{
    public class EmptyDrawing : DrawingModel
    {
        private static EmptyDrawing _instance;

        public static EmptyDrawing Instance => _instance ?? (_instance = new EmptyDrawing());

        private EmptyDrawing() { }

        public override void Draw()
        {
            
        }
    }
}