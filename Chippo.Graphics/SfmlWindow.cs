using SFML.Graphics;

namespace Chippo.Graphics
{
    public class SfmlWindow: IRenderTarget<SfmlWrapperDrawable>
    {
        private readonly RenderWindow window;

        public SfmlWindow(RenderWindow window)
        {
            this.window = window;
        }

        public void Draw(SfmlWrapperDrawable drawable)
        {
            window.Draw(drawable.Drawable);
        }
    }
}