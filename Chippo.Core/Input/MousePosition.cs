using System;
using System.Numerics;

namespace Chippo.Core.Input
{
    public struct MousePosition : IEquatable<MousePosition>
    {
        public int X { get; }
        public int Y { get; }

        public MousePosition(int x, int y)
        {
            X = x;
            Y = y;
        }

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

        public Vector2 AsVector()
        {
            return new Vector2(X,Y);
        }

    }
}