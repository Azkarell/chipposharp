using System;
using System.Threading.Tasks;

namespace Chippo.Actions
{
    interface IEventHandler<in T,TId,TStream>
        where TId : IEquatable<TId>
        where TStream : IEquatable<TStream>
        where T: IEvent<TId,TStream>
    {
        public Guid Id { get; }
        public string Stream { get; }
        Task Handle(T @event);
    }
}
