using System.Collections.Generic;

namespace Chippo.Graphics
{
    public interface IDrawableProvider<out TDrawable> where TDrawable : IDrawable
    {
        IEnumerable<TDrawable> GetDrawables();
    }
}