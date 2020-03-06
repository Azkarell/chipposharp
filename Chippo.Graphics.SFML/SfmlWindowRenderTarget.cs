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
    public class SfmlWindowRenderTarget : IRenderTarget<SfmlContext>, IDisposable
    {
        private RenderWindow renderWindow;

        public SfmlWindowRenderTarget(RenderWindow renderWindow) 
        {
            this.renderWindow = renderWindow;
            renderWindow.SetVisible(true);
            renderWindow.Closed += (s, a) => renderWindow.Close();
            Input = new Input.Input(renderWindow);
        }

        public IInput Input { get; }

        public bool IsOpen => renderWindow.IsOpen;
        
        public Vector2f Dimension => (Vector2f) renderWindow.Size;


        public void Draw(SfmlContext context)
        {
            renderWindow.Clear(global::SFML.Graphics.Color.Black);
            foreach (var drawable in context.GetDrawables())
            {
                renderWindow.Draw(drawable);
            }
            renderWindow.Display();
        }

        public void Close()
        {
            renderWindow.Close();
            Dispose();
        }



        public void Dispose()
        {
            renderWindow.Dispose();
        }

 
    }

}