namespace Chippo.Input.Mouses
{
    public class VerticalWheelDirection : WheelDirection
    {
        public VerticalWheelDirection(IInput input, ILoop loop): base(loop)
        {
            input.RegisterWheelVertical(UpdateValue);
        }
    }
}