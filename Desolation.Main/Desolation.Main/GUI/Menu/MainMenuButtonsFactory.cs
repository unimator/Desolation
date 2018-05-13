using System.Collections.Generic;
using System.Drawing;
using Desolation.Main.Graphics.Drawing.Drawing2D;
using OpenTK;

namespace Desolation.Main.GUI.Menu
{
    public class MainMenuButtonsFactory : MenuButtonsFactoryBase
    {
        private int _yOffset = 0;

        public MainMenuButtonsFactory(int x, int y, Font font, Color color, float opacity = 1.0f) : base (x, y, font, color, opacity) { }

        public override IEnumerable<Button> CreateMenuButtons()
        {
            var buttons = new List<Button>();

            buttons.Add(CreateExitButton());
            return buttons;
        }

        private Button CreateExitButton()
        {
            var text = new Text2D(new Vector2(PositionX, PositionY + _yOffset), 0, GUIResources.exit,
                new Font("Arial", 12.0f), Color.White);
            var button = new Button(text);
            return button;
        }
    }
}