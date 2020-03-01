using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chippo.Core;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.Graphics.Interface;
using SFML.Graphics;
using SFML.System;

namespace Chippo.Graphics.SFML
{
    public class SfmlGraphics2D : Graphics2D<SfmlContext, Drawable>, IDisposable
    {
        private RenderWindow renderWindow;

        public SfmlGraphics2D(IContextFactory<SfmlContext> contextFactory, IDrawableProvider<SfmlContext> drawableProvider, RenderWindow renderWindow) : base(contextFactory, drawableProvider)
        {
            this.renderWindow = renderWindow;
            renderWindow.SetVisible(true);
            renderWindow.Closed += (s, a) => renderWindow.Close();
            Input = new Input.Input(renderWindow);
        }

        public IInput Input { get; }

        public override bool IsOpen => renderWindow.IsOpen;
        
        public Vector2f Dimension => (Vector2f) renderWindow.Size;


        public override Task Update(SfmlContext context)
        {
            renderWindow.Clear(global::SFML.Graphics.Color.Black);
            foreach (var drawable in context.GetDrawables())
            {
                renderWindow.Draw(drawable);
            }
            renderWindow.Display();
            return Task.CompletedTask;
        }

        public override void Close()
        {
            renderWindow.Close();
            Dispose();
        }



        public void Dispose()
        {
            renderWindow.Dispose();
        }

        public static Dimension FromWindow(RenderWindow renderWindow)
        {
            return new Dimension(renderWindow.Size.X, renderWindow.Size.Y);
        }
    }

}