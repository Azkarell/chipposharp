using System;

namespace Chippo.Core.Input
{
    public struct MousePosition : IEquatable<MousePosition>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(MousePosition other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is MousePosition other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static bool operator ==(MousePosition left, MousePosition right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MousePosition left, MousePosition right)
        {
            return !left.Equals(right);
        }
    }
}