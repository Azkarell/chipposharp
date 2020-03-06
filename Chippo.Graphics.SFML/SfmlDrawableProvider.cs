using System.Collections.Generic;
using Chippo.Graphics.Interface;
using SFML.Graphics;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.Graphics.SFML
{
    public class SfmlDrawableProvider<TDrawable>: IDrawableProvider<TDrawable, SfmlContext>
       where TDrawable: IDrawable<SfmlContext>
    {
        private List<TDrawable> drawables = new List<TDrawable>();
        
        public void Add(TDrawable drawable)
        {
            drawables.Add(drawable);
        }

        public void Remove(TDrawable drawable)
        {
            drawables.Remove(drawable);
        }

        public IEnumerable<TDrawable> GetDrawables()
        {
            return drawables;
        }
    }
}