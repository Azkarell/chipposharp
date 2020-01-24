using System;

namespace Chippo.EventSystem.Abstraction
{
    public interface IEventRegistration
    {
        IEventRegistration WithHandler(Type type);
        IEventRegistration WithId(EventId id);
    }
    public interface IEventRegistration<out TEvent>: IEventRegistration
    {
    }

    public static class EventRegistrationExtension
    {
        public static IEventRegistration<T> WithHandler<T, THandler>(this IEventRegistration<T> reg)
            where THandler : IEventHandler<T>
        {
            return (IEventRegistration<T>)reg.WithHandler(typeof(T));
        }

        public static IEventRegistration<T> WithId<T>(this IEventRegistration<T> reg, EventId id)
        {
            return (IEventRegistration<T>)reg.WithId(id);
        }

    }
}