using System.Threading.Tasks;
using Chippo.Core.Interfaces;
using SFML.Graphics;

namespace Chippo.SFML
{
    public class EventDispatcher: IDispatcher
    {
        private readonly RenderWindow window;
        public EventDispatcher(RenderWindow window)
        {
            this.window = window;
        }
    
        public Task DispatchPendingEvents()
        {
            window.DispatchEvents();
            return Task.CompletedTask;
        }

    }
}