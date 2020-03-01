using System.Collections.Generic;

namespace Chippo.Graphics.Interface
{
    public interface IDrawableProvider<T>
    {
        public void Add(IDrawable<T> drawable);
        public IEnumerable<IDrawable<T>> GetDrawables();

    }
}