

using SFML.Graphics;
using SFML.Window;

namespace Chippo.Graphics
{
    public class RenderTargetBuilder
    {
        private VideoMode mode = VideoMode.DesktopMode;
        private string title = "";
        private Styles style = Styles.Default;

        public IRenderTarget Build()
        {
            var window = new SfmlWindow(
                new RenderWindow(mode, title,style)
                );
            return window;
        }

        public RenderTargetBuilder WithVideoMode(VideoMode mode)
        {
            this.mode = mode;
            return this;
        }

        public RenderTargetBuilder WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public RenderTargetBuilder WithStyle(Styles style)
        {
            this.style = style;
            return this;
        }
    }
}
