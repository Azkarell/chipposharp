using System;

namespace Chippo.EventSystem.Abstraction
{
    public struct StreamId : IEquatable<StreamId>
    {

        private object Id { get; }

        public bool Equals(StreamId other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object? obj)
        {
            return obj is StreamId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(StreamId left, StreamId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(StreamId left, StreamId right)
        {
            return !left.Equals(right);
        }

        private StreamId(object id)
        {
            Id = id;
        }

        public static StreamId FromName(string name)
        {
            return new StreamId(name);
        }
    }
}