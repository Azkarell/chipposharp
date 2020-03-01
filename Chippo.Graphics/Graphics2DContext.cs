using System.Collections.Generic;
using System.Numerics;
using Chippo.Math;

namespace Chippo.Graphics
{
    public abstract class Graphics2DContext<TDrawable>
    {
        public abstract Graphics2DContext<TDrawable> Square(Color color, Transformation transformation);
        public abstract Graphics2DContext<TDrawable> Circle(Color color, Transformation transformation);

        public abstract IEnumerable<TDrawable> GetDrawables();

        public abstract Vector2 Dimension { get; }

    }
}