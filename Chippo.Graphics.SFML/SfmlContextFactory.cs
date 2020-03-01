using Chippo.Core.Interfaces;
using Chippo.Graphics.Interface;
using SFML.Graphics;

namespace Chippo.Graphics.SFML
{
    public class SfmlContextFactory: IContextFactory<SfmlContext>
    {
        private readonly RenderWindow renderWindow;

        public SfmlContextFactory(RenderWindow renderWindow)
        {
            this.renderWindow = renderWindow;
        }
        public SfmlContext Create(SfmlContext oldContext)
        {
            return new SfmlContext(renderWindow);
        }
    }
}