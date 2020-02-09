using Chippo.Core.Input.Axis;

namespace Chippo.Core.Input.Keyboards
{
    class KeyDirection: IDirection
    {
        private readonly KeyboardKey key;
        private readonly IInput input;

        public KeyDirection(KeyboardKey key, IInput input)
        {
            this.key = key;
            this.input = input;
        }


        public float GetValue()
        {
            return input.IsPressed(key) ? 1 : 0;
        }
    }
}