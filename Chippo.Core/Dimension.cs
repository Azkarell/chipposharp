using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    public class Dimension : IDimension
    {
        public Dimension(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public float Width { get; }
        public float Height { get; }


    }
}