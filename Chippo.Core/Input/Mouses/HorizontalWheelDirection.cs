using Chippo.Core.Interfaces;

namespace Chippo.Core.Input.Mouses
{
    public class HorizontalWheelDirection : WheelDirection
    {
        public HorizontalWheelDirection(IInput input, ILoop loop):base(loop)
        {
            input.SubscribeWheelHorizontal(UpdateValue);
        }
    }
}