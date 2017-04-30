using System;
using System.Collections.Generic;
using Desolation.Graphics.Graphics.Drawables;

namespace Desolation.Graphics.Graphics.Texture.TextureManagers
{
    public class FacesChangedEventArgs : EventArgs
    {
        public IEnumerable<SquarePrismFaces> FacesChanged { get; set; }
    }
}