using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chippo.Actions
{

    interface IMediator<TId, TStream>
        where TId : IEquatable<TId>
        where TStream : IEquatable<TStream>
    {
        Task Publish(IEvent<TId, TStream> @event);
        void Subscribe(IEventHandler<IEvent<TId,TStream>,TId,TStream> eventHandler);
    }
}
