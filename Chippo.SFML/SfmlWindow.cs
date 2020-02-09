using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using SFML.Graphics;
using SFML.System;

namespace Chippo.SFML
{
    public class SfmlWindow : IOutput, IDisposable
    {
        private readonly IEnumerable<Drawable> drawables;
        private RenderWindow renderWindow;

        public SfmlWindow(RenderWindow renderWindow, IEnumerable<Drawable> drawables)
        {
            this.renderWindow = renderWindow;
            renderWindow.Closed += (s, a) => renderWindow.Close();
            Input = new Input.Input(renderWindow);
            this.drawables = drawables;
        }

        public IInput Input { get; }

        public bool IsOpen => renderWindow.IsOpen;

        public Vector2f Dimension => (Vector2f) renderWindow.Size;

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