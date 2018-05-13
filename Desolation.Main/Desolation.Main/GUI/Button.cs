using System.Collections.Generic;
using Desolation.Main.Graphics;
using Desolation.Main.Graphics.Drawing;

namespace Desolation.Main.GUI
{
    public class Button : IDrawable
    {
        private readonly DrawingModel _drawingModel;

        public Button(DrawingModel drawingModel)
        {
            _drawingModel = drawingModel;
        }

        public IEnumerable<DrawingModel> GetDrawingModel()
        {
            yield return _drawingModel;
        }
    }
}