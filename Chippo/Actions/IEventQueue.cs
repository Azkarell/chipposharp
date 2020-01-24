using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chippo.Actions
{
    interface IEventQueue
    {
        void Enqueue(IEvent @event);
        Task<IEvent> DequeueAsync();
    }
}
