using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Chippo.EventSystem.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Chippo.EventSystem
{
    class EventSystemBuilder: IEventSystemBuilder
    {
        private readonly IServiceCollection services;
        private StreamCollection streams = new StreamCollection();

        public EventSystemBuilder(IServiceCollection services)
        {
            this.services = services;
        }
        public IStreamRegistration AddStream(StreamId id)
        {
            StreamRegistration reg = new StreamRegistration(id);
            streams.Add(reg);
            return reg;
        }

        public EventSystem Build()
        {

        }

        private Dictionary<Type, List<HandlerWrapper>> GenerateHandler()
        {
            var ret = new Dictionary<Type, List<HandlerWrapper>>();
            foreach (var stream in streams)
            {
                var handlers = stream.GetHandlerMap();
                MergeMap(ret, handlers);
            }
        }

    }

    class EventSystem
    {
        private readonly Dictionary<Type, List<HandlerWrapper>> handler;

        public EventSystem(Dictionary<Type, List<HandlerWrapper>> handler)
        {
            this.handler = handler;
        }

        public async Task Execute(Event @event)
        {
            var type = @event.Payload.GetType();
            if (handler.TryGetValue(type, out var handlers))
            {
                foreach (var h in handlers)
                {
                    await h.HandleAsync(@event);
                }
            }
        }

        public IBus CreateBus()
        {
            var bus = new Bus();
        }
    }

    internal class Bus: IBus
    {
        private EventSystem system;
        private List<Task>
        public Bus(EventSystem system)
        {
            this.system = system;
        }


        public void Publish<T>(T @event)
        {
            
        }
    }


    abstract class HandlerWrapper
    {
        public abstract Task HandleAsync(Event @event);

    }

    class HandlerWrapper<T> : HandlerWrapper
    {
        private readonly IEventHandler<T> handler;
        public HandlerWrapper(IEventHandler<T> handler)
        {
            this.handler = handler;
        }
        public override async Task HandleAsync(Event @event)
        {
            await handler.HandleAsync((T) @event.Payload);
        }
    }
    

    internal class Event : IEquatable<Event>
    {
        private EventId eventId;
        private StreamId streamId;
        public object Payload { get; }
        public Event(EventId eventId, StreamId streamId, object payload)
        {
            Payload = payload;
            this.eventId = eventId;
            this.streamId = streamId;
        }

        public bool Equals(Event? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return eventId.Equals(other.eventId) && streamId.Equals(other.streamId) && Payload.Equals(other.Payload);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Event) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(eventId, streamId, Payload);
        }

        public static bool operator ==(Event? left, Event? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Event? left, Event? right)
        {
            return !Equals(left, right);
        }
    }
}