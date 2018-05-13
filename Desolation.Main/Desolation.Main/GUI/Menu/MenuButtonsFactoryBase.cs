using System;
using System.Collections.Generic;
using System.Drawing;

namespace Desolation.Main.GUI.Menu
{
    public abstract class MenuButtonsFactoryBase
    {
        protected int PositionX;
        protected int PositionY;
        protected Font Font;
        protected Color Color;
        protected float Opacity;

        protected MenuButtonsFactoryBase(int x, int y, Font font, Color color, float opacity = 1.0f)
        {
            PositionX = x;
            PositionY = y;
            Font = font;
            Color = color;

            if (opacity < 0.0f || opacity > 1.0f)
                throw new ArgumentException($"{nameof(opacity)} value should be between 0 and 1.");

            Opacity = opacity;
        }

        public abstract IEnumerable<Button> CreateMenuButtons();
    }
}