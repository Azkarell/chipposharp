using System;

namespace Chippo.Actions
{
    interface IEvent<TId, TStream> : IEquatable<IEvent<TId, TStream>>
        where TId : IEquatable<TId>
        where TStream : IEquatable<TStream>
    {
        TId Id { get; }
        TStream Stream { get; }
    }
}
