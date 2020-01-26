using System;
using System.Collections.Generic;
using Chippo.EventSystem.Abstraction;

namespace Chippo.EventSystem
{
    abstract class EventRegistration
    {
        public abstract (Type, (StreamId, EventId)) GetIdTuple(StreamId id);
        public abstract IEnumerable<HandlerWrapper> GetWrapper();
    }

    class EventRegistration<T>: EventRegistration, IEventRegistration<T>
    {
        private EventId id;
        private readonly HandlerCollection handlers;
        private readonly Type eventType = typeof(T);
        private readonly Type handlerType = typeof(IEventHandler<T>);

        public EventRegistration(EventId id)
        {
            this.id = id;
            handlers = new HandlerCollection(handlerType);
        }


        public IEventRegistration<T> WithHandler<THandler>() where THandler : IEventHandler<T>
        {
            handlers.Add(typeof(THandler));
            return this;
        }

        public IEventRegistration<T> WithId(EventId id)
        {
            this.id = id;
            return this;
        }

        public override (Type, (StreamId, EventId)) GetIdTuple(StreamId stream)
        {
            return (eventType, (stream, id));
        }

        public override IEnumerable<HandlerWrapper> GetWrapper()
        {
            var wrapper = new List<HandlerWrapper>();
            foreach (var handler in handlers)
            {
                var eh = (IEventHandler<T>) Activator.CreateInstance(handler);
                var w = new HandlerWrapper<T>(eh);
                wrapper.Add(w);
            }
            return wrapper;
        }
    }
}