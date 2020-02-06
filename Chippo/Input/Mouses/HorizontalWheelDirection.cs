namespace Chippo.Input.Mouses
{
    public class HorizontalWheelDirection : WheelDirection
    {
        public HorizontalWheelDirection(IInput input, ILoop loop):base(loop)
        {
            input.RegisterWheelHorizontal(UpdateValue);
        }
    }
}