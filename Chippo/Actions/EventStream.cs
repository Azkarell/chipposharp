using System;
using System.Runtime.CompilerServices;

namespace Chippo.Actions
{
    struct EventStream : IEquatable<EventStream>
    {
        public string Name { get; }

        public EventStream([CallerMemberName] string name = "")
        {
            Name = name;
        }

        public bool Equals(EventStream other)
        {
            return Name == other.Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is EventStream other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static bool operator ==(EventStream left, EventStream right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EventStream left, EventStream right)
        {
            return !left.Equals(right);
        }
    }
}