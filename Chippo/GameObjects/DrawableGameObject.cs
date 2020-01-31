using SFML.Graphics;

namespace Chippo.GameObjects
{
    public abstract class DrawableGameObject: GameObject
    {
        public abstract Drawable AsDrawable { get; }
    }
}