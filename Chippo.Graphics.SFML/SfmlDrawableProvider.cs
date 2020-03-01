using System.Collections.Generic;
using Chippo.Graphics.Interface;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.Graphics.SFML
{
    public class SfmlDrawableProvider: IDrawableProvider<SfmlContext>
    {
        private List<IDrawable<SfmlContext>> drawables = new List<IDrawable<SfmlContext>>();
        
        public void Add(IDrawable<SfmlContext> drawable)
        {
            drawable.OnDestroy += args => drawables.Remove(args.Drawable);
            drawables.Add(drawable);
        }

        public IEnumerable<IDrawable<SfmlContext>> GetDrawables()
        {
            return drawables;
        }
    }
}