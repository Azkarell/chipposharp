using System.Collections.Generic;
using System.Threading.Tasks;
using Chippo.Core;
using Chippo.Core.Interfaces;
using Chippo.Graphics.Interface;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.Graphics
{
    public class Graphics2D<TExternalDrawable, TContext, TInternalDrawable> : IOutput
       where TExternalDrawable : IDrawable<TContext>
       where TContext: class, IGraphics2DContext<TInternalDrawable, TContext>
    {
        private TContext? context;
        private readonly IContextFactory<TContext> contextFactory;
        private readonly IRenderTarget<TContext> renderTarget;
        private readonly IDrawableProvider<TExternalDrawable, TContext> drawableProvider;

        public Graphics2D(
            IContextFactory<TContext> contextFactory,
            IRenderTarget<TContext> renderTarget,
            IDrawableProvider<TExternalDrawable, TContext> drawableProvider)
        { 
            this.contextFactory = contextFactory;
            this.renderTarget = renderTarget;
            this.drawableProvider = drawableProvider;
        }


        public bool IsOpen => renderTarget.IsOpen;

        public Task Update(IEnumerable<TExternalDrawable> drawables)
        {
            if (IsOpen)
            {
                context = contextFactory.Create(context);
                foreach (var drawable in drawables)
                {
                    drawable.Draw(context);
                }
                renderTarget.Draw(context);
            }
            return Task.CompletedTask;
        }



        public void Close()
        {
            renderTarget.Close();
        }

        public async Task Update()
        {
            await Update(drawableProvider.GetDrawables());
        }
    }

    public interface IRenderTarget<in TContext>
    {
        void Draw(TContext context);
        void Close();
        bool IsOpen { get; }
    }
}