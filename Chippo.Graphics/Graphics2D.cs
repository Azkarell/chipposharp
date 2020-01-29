using System;
using System.Text;
using Chippo.Core;
using Chippo.Core.Component;
using Chippo.Core.Extensions;
using SFML.Graphics;

namespace Chippo.Graphics
{
    public class Graphics2D: Graphics
    {
        private readonly IRenderTarget renderTarget;
        private readonly IDrawableProvider drawableProvider;

        public Graphics2D(IRenderTarget renderTarget, IDrawableProvider drawableProvider)
        {
            this.renderTarget = renderTarget;
            this.drawableProvider = drawableProvider;
        }

        public override ApplicationState Update(TimeSpan delta)
        {
            foreach (var drawable in drawableProvider.GetDrawables())
            {
                renderTarget.Draw(drawable);
            }
            return ApplicationState.Running;
        }

    }
}
