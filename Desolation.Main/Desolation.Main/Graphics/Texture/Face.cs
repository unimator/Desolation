﻿using System.Drawing;
using Desolation.Graphics.Graphics.Texture;

namespace Desolation.Main.Graphics.Texture
{
    public struct Face
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }

        public Face(Texture2D texture, Color color)
        {
            Texture = texture;
            Color = color;
        }
    }
}