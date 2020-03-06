using System.Collections.Generic;

namespace Chippo.Graphics.Interface
{
    public interface IDrawableProvider<T, TContext>
      where T: IDrawable<TContext>
    {
        public void Add(T drawable);
        public void Remove(T drawable);
        public IEnumerable<T> GetDrawables();

    }
}