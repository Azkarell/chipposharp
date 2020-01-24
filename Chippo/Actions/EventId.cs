using System;

namespace Chippo.Actions
{
    struct EventId: IEquatable<EventId>
    {
        private Guid _id;
        

        public bool Equals(EventId other)
        {
            return _id.Equals(other._id);
        }

        public override bool Equals(object? obj)
        {
            return obj is EventId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public static bool operator ==(EventId left, EventId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EventId left, EventId right)
        {
            return !left.Equals(right);
        }

        public static EventId NewId()
        {
            return new EventId
            {
                _id = Guid.NewGuid()
            };
        }
    }
}