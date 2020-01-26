using System;

namespace Chippo.EventSystem.Abstraction
{

    public interface IEventRegistration<out TEvent>
    {
        IEventRegistration<TEvent> WithHandler<T>() where T: IEventHandler<TEvent>;
        IEventRegistration<TEvent> WithId(EventId id);
    }

}