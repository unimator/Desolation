using System;
using System.Collections.Generic;
using System.Drawing;
using Desolation.Graphics.Graphics.Drawables;

namespace Desolation.Graphics.Graphics.Texture.TextureManagers
{
    public class SquarePrismTextureManager : PolygonTextureManager
    {
        private static SquarePrismTextureManager _defaultInstance;

        public static SquarePrismTextureManager Default => _defaultInstance ?? (_defaultInstance = new SquarePrismTextureManager());

        private Face[] _faces;
        public Face[] Faces
        {
            get { return _faces; }
            set
            {
                var oldFaces = _faces;
                _faces = value;
                if (value.Length != Enum.GetValues(typeof(SquarePrismFaces)).Length)
                    throw new ArgumentException("Number of faces mismatch");
                if(oldFaces != null)
                    OnFacesChanged(oldFaces, value);
            }
        }

        public delegate void FacesChangedEventHandler(object o, FacesChangedEventArgs args);
        public event FacesChangedEventHandler FacesChanged;

        public SquarePrismTextureManager()
            :
            this(Texture2D.None)
        { }

        public SquarePrismTextureManager(Texture2D texture)
            :
            this(texture, Color.White)
        { }

        public SquarePrismTextureManager(Texture2D texture, Color color)
            :
            this(new Face(texture, color))
        { }

        public SquarePrismTextureManager(Face face)
        {
            Faces = new Face[Enum.GetValues(typeof(SquarePrismFaces)).Length];
            for (int i = 0; i < Faces.Length; ++i)
            {
                Faces[i] = face;
            }
        }

        public SquarePrismTextureManager(Face[] faces)
        {
            int numberOfFaces = Enum.GetValues(typeof(SquarePrismFaces)).Length;
            if (faces.Length != numberOfFaces)
                throw new ArgumentException("Number of faces mismatch");

            Faces = faces;
        }

        protected virtual void OnFacesChanged(Face[] oldFaces, Face[] newFaces)
        {
            List<SquarePrismFaces> facesDifferent = new List<SquarePrismFaces>();
            for (int i = 0; i < Enum.GetValues(typeof(SquarePrismFaces)).Length; ++i)
            {
                if(!oldFaces[i].Equals(newFaces[i]))
                    facesDifferent.Add((SquarePrismFaces)i);
            }
            FacesChanged?.Invoke(this, new FacesChangedEventArgs() {FacesChanged = facesDifferent});
        }
    }
}