using System;
using System.Collections.Generic;
using Chippo.EventSystem.Abstraction;

namespace Chippo.EventSystem
{
    class StreamRegistration : IStreamRegistration
    {
        private StreamId id;
        private EventRegistrationCollection eventsRegistration = new EventRegistrationCollection();
        
        public StreamRegistration(StreamId id)
        {
            this.id = id;
        }

        public IEventRegistration<T> AddEvent<T>()
        {
            return AddEvent<T>(EventId.NewId());
        }

        public IEventRegistration<T> AddEvent<T>(EventId id)
        {
            var reg = new EventRegistration<T>(id);
            eventsRegistration.Add(reg);
            return reg;
        }

        public IStreamRegistration WithName(string name)
        {
            id = StreamId.FromName(name);
            return this;
        }


        public Dictionary<Type, List<HandlerWrapper>> GetHandlerMap()
        {
        }
    }
}