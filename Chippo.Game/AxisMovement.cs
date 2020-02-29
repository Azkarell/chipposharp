using System;
using System.Numerics;
using Chippo.Core.Input.Axis.Interface;
using Chippo.Math;
using Chippo.Movement.Interface;

namespace Chippo.Movement
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

        public Vector2 Apply(in Vector2 oldPosition, in TimeSpan delta)
        {
            return oldPosition + new Vector2(GetX(delta), GetY(delta));
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