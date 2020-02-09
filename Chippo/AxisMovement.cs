using System;
using Chippo.Core.Input.Axis;
using SFML.System;

namespace Chippo
{
    class AxisMovement : IMovement
    {
        private readonly float speed;
        private readonly IAxis2D axis;
        private readonly IMovementUnit unit;

        public AxisMovement(float speed, IAxis2D axis, IMovementUnit unit)
        {
            this.speed = speed;
            this.axis = axis;
            this.unit = unit;
        }

        public Vector2f Apply(in Vector2f oldPosition, in TimeSpan delta)
        {
            return oldPosition + new Vector2f(GetX(delta), GetY(delta));
        }

        private float GetY(in TimeSpan delta)
        {
            return speed * axis.YAxis * (float)delta.TotalSeconds * unit.PixelsPerSecond;
        }

        private float GetX(in TimeSpan delta)
        {
            return speed * axis.XAxis * (float)delta.TotalSeconds * unit.PixelsPerSecond;
        }
    }
}