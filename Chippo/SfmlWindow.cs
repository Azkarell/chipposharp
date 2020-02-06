using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Chippo.Input;
using Chippo.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Chippo
{
    class SfmlWindow : IOutput, IDisposable
    {
        private readonly RenderWindow renderWindow;
        private readonly IEnumerable<Drawable> drawables;

        public SfmlWindow(RenderWindow renderWindow, IEnumerable<Drawable> drawables)
        {
            this.renderWindow = renderWindow;
            renderWindow.Closed += (s, a) => renderWindow.Close();
            this.drawables = drawables;
            Input = new Input.Input(renderWindow);
            
        }

        public IInput Input { get; }

        public bool IsOpen => renderWindow.IsOpen;

        public Vector2f Dimension => new Vector2f(renderWindow.Size.X, renderWindow.Size.Y);

        public Task Update()
        {
            renderWindow.Clear();
            foreach (var drawable in drawables)
            {
                renderWindow.Draw(drawable);
            }
            renderWindow.Display();
            return Task.CompletedTask;
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