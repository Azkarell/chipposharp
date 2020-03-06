using Chippo.Graphics.Interface;
using Chippo.Math;

namespace Chippo.GameObjects
{
    public abstract class DrawableGameObject<T> : GameObject, IDrawable<T>
    {
        public abstract void Draw(T context);
        public Transformation Transformation { get; set; } = Transformation.Identity;

    }
}