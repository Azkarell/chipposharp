using Chippo.Common;
using SFML.Window;
using System;

namespace Chippo.Actions
{
    interface IKeyboardEventFactory<TId, TStream>: 
        IFactory<KeyEventArgs,IEvent<TId,TStream>?>
        where TId : IEquatable<TId>
        where TStream : IEquatable<TStream>
    {
        IEvent<TId, TStream>? Create(KeyEventArgs s);
    }
}