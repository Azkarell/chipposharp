using System;
using Chippo.Input.Axis;

namespace Chippo.Input.Mouses
{
    abstract class MouseDirection : IDirection
    {
        private readonly IInput input;
        private readonly IDimension dimension;
        private readonly float deadZone;
        public MouseDirection(IInput input, IDimension dimension, float deadZone)
        {
            this.input = input;
            this.dimension = dimension;
            this.deadZone = deadZone;
        }

        public float GetValue()
        {
            var val = GetBaseValue(input, dimension);
            var deadzoned = ApplyDeadZone(val, deadZone);
            return ApplyClamp(Orientation * deadzoned);
        }

        protected abstract float Orientation { get; }

        protected abstract float GetBaseValue(IInput input, IDimension dimension);

        private static float ApplyDeadZone(float baseValue, float deadZone)
        {
            return Math.Abs(baseValue) < deadZone ? 0 : baseValue;
        }

        private static float ApplyClamp(float value)
        {
            return Math.Clamp(value, 0, 1);
        }

    }
}