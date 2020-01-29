using SFML.Graphics;

namespace Chippo.Graphics
{
    public abstract class SfmlWrapperDrawable: IDrawable
    {
        public Drawable Drawable { get; }

        public SfmlWrapperDrawable(Drawable drawable)
        {
            Drawable = drawable;
        }

    }
}