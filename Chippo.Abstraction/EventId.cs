using System;

namespace Chippo.EventSystem.Abstraction
{
    public struct EventId : IEquatable<EventId>
    {
        private object Id { get; }

        public bool Equals(EventId other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is EventId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(EventId left, EventId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EventId left, EventId right)
        {
            return !left.Equals(right);
        }

        private EventId(object id)
        {
            Id = id;
        }

        public static EventId NewId()
        {
            return new EventId(Guid.NewGuid());
        }
        public static EventId FromName(string name)
        {
            return new EventId(name);
        }


        
    }
}