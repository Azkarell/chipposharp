using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using Chippo.EventSystem.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Chippo.EventSystem
{
    public class EventSystemBuilder: IEventSystemBuilder
    {
        private readonly IServiceCollection _services;
        private StreamCollection _streams = new StreamCollection();

        public EventSystemBuilder(IServiceCollection services)
        {
            _services = services;
        }
        public IStreamRegistration AddStream(StreamId id)
        {
            IStreamRegistration reg = new StreamRegistration(id);
            _streams.Add(reg);
            return reg;
        }

        public EventSystem Build()
        {

        }
    }

    internal class StreamCollection: ICollection<IStreamRegistration>
    {
        private List<IStreamRegistration> registrations = new List<IStreamRegistration>();
        public StreamCollection()
        {

        }

        public IEnumerator<IStreamRegistration> GetEnumerator()
        {
            return registrations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) registrations).GetEnumerator();
        }

        public void Add(IStreamRegistration item)
        {
            registrations.Add(item);
        }

        public void Clear()
        {
            registrations.Clear();
        }

        public bool Contains(IStreamRegistration item)
        {
            return registrations.Contains(item);
        }

        public void CopyTo(IStreamRegistration[] array, int arrayIndex)
        {
            registrations.CopyTo(array, arrayIndex);
        }

        public bool Remove(IStreamRegistration item)
        {
            return registrations.Remove(item);
        }

        public int Count => registrations.Count;

        public bool IsReadOnly => ((ICollection<IStreamRegistration>) registrations).IsReadOnly;
    }

    public class StreamRegistration : IStreamRegistration
    {
        private StreamId _id;
        private EventRegistrationCollection _eventsRegistration = new EventRegistrationCollection();
        public StreamRegistration(StreamId id)
        {
            _id = id;
        }

        public IEventRegistration<T> AddEvent<T>()
        {
            EventRegistration<T> reg = new EventRegistration<T>();
            _eventsRegistration.Add(reg);
            return reg;
        }

        public IStreamRegistration WithName(string name)
        {
            throw new System.NotImplementedException();
        }
    }

    public class EventRegistration<T>: IEventRegistration<T>
    {
        public IEventRegistration WithHandler(Type type)
        {
            throw new NotImplementedException();
        }

        public IEventRegistration WithId(EventId id)
        {
            throw new NotImplementedException();
        }
    }


    internal class EventRegistrationCollection: ICollection<IEventRegistration>
    {
        private List<IEventRegistration> _types = new List<IEventRegistration>();
        public IEnumerator<IEventRegistration> GetEnumerator()
        {
            return _types.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _types).GetEnumerator();
        }

        public void Add(IEventRegistration item)
        {
            _types.Add(item);
        }

        public void Clear()
        {
            _types.Clear();
        }

        public bool Contains(IEventRegistration item)
        {
            return _types.Contains(item);
        }

        public void CopyTo(IEventRegistration[] array, int arrayIndex)
        {
            _types.CopyTo(array, arrayIndex);
        }

        public bool Remove(IEventRegistration item)
        {
            return _types.Remove(item);
        }

        public int Count => _types.Count;

        public bool IsReadOnly => ((ICollection<IEventRegistration>) _types).IsReadOnly;
    }
}