using System.Threading.Tasks;
using Chippo.Interfaces;
using SFML.Graphics;

namespace Chippo
{
    internal class EventDispatcher: IDispatcher
    {
        private readonly RenderWindow window;
        public EventDispatcher(RenderWindow window)
        {
            this.window = window;
        }

    
        public void DispatchPendingEvents()
        {
            window.DispatchEvents();
        }
    }
}