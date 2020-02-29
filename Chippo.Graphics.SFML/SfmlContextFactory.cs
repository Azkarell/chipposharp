using Chippo.Core.Interfaces;
using SFML.Graphics;

namespace Chippo.Graphics.SFML
{
    public class SfmlContextFactory: IContextFactory<SfmlContext>
    {
        public SfmlContext Create(SfmlContext oldContext)
        {
            return new SfmlContext();
        }
    }
}