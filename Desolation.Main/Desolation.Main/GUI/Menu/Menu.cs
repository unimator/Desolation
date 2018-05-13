using System.Collections.Generic;
using Desolation.Main.Graphics;
using Desolation.Main.Graphics.Drawing;

namespace Desolation.Main.GUI.Menu
{
    public class Menu : IDrawable
    {
        public bool Visible { get; set; }

        private IEnumerable<Button> _buttons = new List<Button>();
        private readonly MenuButtonsFactoryBase _menuButtonsFactoryBase;

        public Menu(MenuButtonsFactoryBase menuButtonsFactory)
        {
            _menuButtonsFactoryBase = menuButtonsFactory;
            _buttons = menuButtonsFactory.CreateMenuButtons();
        }

        public IEnumerable<DrawingModel> GetDrawingModel()
        {
            if (!Visible)
                yield break;

            foreach (var button in _buttons)
            {
                foreach (var drawingModel in button.GetDrawingModel())
                    yield return drawingModel;
            }
        }
    }
}