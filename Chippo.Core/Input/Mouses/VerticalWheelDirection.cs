using Chippo.Core.Interfaces;

namespace Chippo.Core.Input.Mouses
{
    public class VerticalWheelDirection : WheelDirection
    {
        public VerticalWheelDirection(IInput input, ILoop loop): base(loop)
        {
            input.SubscribeWheelVertical(UpdateValue);
        }
    }
}