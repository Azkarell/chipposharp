using System.Threading.Tasks;
using Chippo.Core;
using Chippo.Core.Interfaces;
using Chippo.Graphics.Interface;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.Graphics
{
    public abstract class Graphics2D<TContext, TDrawable> : IOutput<TContext>
        where TContext : Graphics2DContext<TDrawable>
    {
        private TContext context;
        private readonly IContextFactory<TContext> contextFactory;
        private readonly IDrawableProvider<TContext> drawableProvider;

        public Graphics2D(IContextFactory<TContext> contextFactory,  IDrawableProvider<TContext> drawableProvider)
        {
            this.contextFactory = contextFactory;
            this.drawableProvider = drawableProvider;
        }

     

        public abstract bool IsOpen { get; }
        public Task Update()
        {
            context = contextFactory.Create(context);
            foreach (var drawable in drawableProvider.GetDrawables())
            {
                drawable.Draw(context);
            }
            return Update(context);
        }

        public abstract Task Update(TContext context);


        public abstract void Close();
    }


}