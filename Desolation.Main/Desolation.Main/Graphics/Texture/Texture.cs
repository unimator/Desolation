namespace Desolation.Main.Graphics.Texture
{
    public abstract class Texture
    {
        public int? Id { get; protected set; }

        public abstract void BindTexture();
    }
}
