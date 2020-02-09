using Chippo.Core.Interfaces;

namespace Chippo.Core.Input.Mouses
{
    class LeftMouseDirection : MouseDirection
    {


        public LeftMouseDirection(IInput input, IDimension dimension, float deadZone) :
            base(input, dimension, deadZone)
        {

        }


        protected override float Orientation => -1;

        protected override float GetBaseValue(IInput input, IDimension dimension)
        {
            return 2 * (input.MousePosition.X / dimension.Width) - 1;
        }


    }
}