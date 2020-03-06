using System.Collections.Generic;
using System.Net;
using System.Numerics;
using Chippo.Graphics.Interface;
using Chippo.Math;

namespace Chippo.Graphics
{
    public interface IGraphics2DContext<TDrawable, TSelf>
       where TSelf: IGraphics2DContext<TDrawable, TSelf>
    {
        TSelf Square(Transformation transformation, Material material);
        Vector2 Dimension { get; }
        IEnumerable<TDrawable> GetDrawables();

    }

}