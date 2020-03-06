using Chippo.Math;
using SFML.Graphics;

namespace Chippo.Graphics.SFML.Interface
{
    public interface ISfmlRenderStrategy
    {
        Drawable CreateSquare(Transformation transformation, Material material);
    }
}