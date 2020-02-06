using System;
using Chippo.Input.Axis;
using SFML.System;

namespace Chippo
{
    class AxisMovement : IMovement
    {
        private readonly float speed;
        private readonly IAxis2D axis;

        public AxisMovement(float speed, IAxis2D axis)
        {
            this.speed = speed;
            this.axis = axis;
        }

        public Vector2f Apply(in Vector2f oldPosition, in TimeSpan delta)
        {
            return new Vector2f(oldPosition.X + GetX(delta), oldPosition.Y + GetY(delta));
        }

        private float GetY(in TimeSpan delta)
        {
            return speed * axis.YAxis + (float)delta.TotalSeconds;
        }

        private float GetX(in TimeSpan delta)
        {
            return speed * axis.XAxis + (float)delta.TotalSeconds;
        }
    }
}