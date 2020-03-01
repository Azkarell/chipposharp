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

        public Vector2 GetDelta(in TimeSpan delta)
        {
            return new Vector2(GetX(delta), GetY(delta));
        }

        public Rotation GetRotation(in TimeSpan delta)
        {

            return Rotation.Zero;
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