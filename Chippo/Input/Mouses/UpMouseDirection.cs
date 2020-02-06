namespace Chippo.Input.Mouses
{
    class UpMouseDirection : MouseDirection
    {
        public UpMouseDirection(IInput input, IDimension dimension, float deadZone) :
            base(input, dimension, deadZone)
        {
        }

        protected override float Orientation => -1;

        protected override float GetBaseValue(IInput input, IDimension dimension)
        {
            return 2 * (input.MousePosition.Y / dimension.Height) - 1;
        }

    }
}