using System;
using Chippo.Interfaces;
using SFML.System;

namespace Chippo
{
    public class MouseAxis2D : IAxis2D
    {
        private readonly Input input;
        private readonly Vector2f dimensions;
        private readonly float deadZone;

        public MouseAxis2D(Input input, Vector2f dimensions, float deadZone)
        {
            this.input = input;
            this.dimensions = dimensions;
            this.deadZone = deadZone;
        }

        public float XAxis => GetX();
        public float YAxis => GetY();

        private float GetX()
        {
            var val = 2*(input.MousePosition.X / dimensions.X) - 1;
            if (Math.Abs(val) < deadZone) return 0;
            return val;
        }

        private float GetY()
        {
            var val = 2 * (input.MousePosition.Y / dimensions.Y) - 1;
            if (Math.Abs(val) < deadZone) return 0;
            return val;
        }
    }

    public class Axis2DProxy : IAxis2D
    {
        private IAxis2D axis2DImplementation;

        public Axis2DProxy(IAxis2D axis2DImplementation)
        {
            this.axis2DImplementation = axis2DImplementation;
        }

        public float XAxis => axis2DImplementation.XAxis;

        public float YAxis => axis2DImplementation.YAxis;

        public void SwitchImplementation(IAxis2D axis2D)
        {
            axis2DImplementation = axis2D;
        }
    }
}