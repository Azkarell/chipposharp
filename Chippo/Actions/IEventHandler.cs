using System;
using System.Threading.Tasks;

namespace Chippo.Actions
{
    interface IEventHandler
    {
        Task Handle(IEvent @event);
    }
}
