using Chippo.Core;
using Chippo.Core.Interfaces;
using SFML.Graphics;

namespace Chippo
{
    class Dimension : IDimension
    {
        public Dimension(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }
        public float Height { get; }

        public static Dimension FromWindow(RenderWindow renderWindow)
        {
            return new Dimension(renderWindow.Size.X,renderWindow.Size.Y);
        }
    }
}