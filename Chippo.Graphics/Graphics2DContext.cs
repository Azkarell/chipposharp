using System.Collections.Generic;
using Chippo.Math;

namespace Chippo.Graphics
{
    public abstract class Graphics2DContext<TDrawable>
    {
        public abstract Graphics2DContext<TDrawable> Square(Color color, ITransformation transformation);
        public abstract Graphics2DContext<TDrawable> Circle(Color color, ITransformation transformation);

        public abstract IEnumerable<TDrawable> GetDrawables();
    }
}