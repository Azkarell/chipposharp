using Chippo.Core.Input.Axis.Interface;

namespace Chippo.Core.Input.Axis
{
    public class Axis2DConfiguration
    {
        public Axis2DConfiguration(IDirection left,
            IDirection right,
            IDirection up,
            IDirection down)
        {
            Left = left;
            Right = right;
            Up = up;
            Down = down;
        }

        public Axis2DConfiguration(IDirection horizontal, IDirection vertical)
        {
            Left = new TwoWayDirectionWrapper(horizontal, true);
            Right = new TwoWayDirectionWrapper(horizontal, false);
            Up = new TwoWayDirectionWrapper(vertical, true);
            Down = new TwoWayDirectionWrapper(vertical, false);
        }

        class TwoWayDirectionWrapper : IDirection
        {
            private readonly IDirection impl;
            private readonly bool negative;

            public TwoWayDirectionWrapper(IDirection impl, bool negative)
            {
                this.impl = impl;
                this.negative = negative;
            }

            public float GetValue()
            {
                var val = impl.GetValue();
                if (negative)
                {
                    if (val <= 0)
                        return -1 * val;
                    return 0;
                }
                else
                {
                    if (val >= 0)
                        return val;
                    return 0;
                }

            }
        }
        public IDirection Left { get; }
        public IDirection Right { get; }
        public IDirection Up { get; }
        public IDirection Down { get; }
    }
}