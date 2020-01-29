using System;

namespace Chippo.Core
{
    public interface IEvent
    {
        bool HasPayload { get; }
        T GetPayload<T>();
    }
}