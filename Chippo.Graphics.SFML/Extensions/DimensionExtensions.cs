using Chippo.Core;
using SFML.Graphics;

namespace Chippo.Graphics.SFML.Extensions
{
    public class DimensionExtensions
    {
        public static Dimension FromWindow(RenderWindow renderWindow)
        {
            return new Dimension(renderWindow.Size.X, renderWindow.Size.Y);
        }
    }
}