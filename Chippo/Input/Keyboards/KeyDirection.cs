using Chippo.Input.Axis;

namespace Chippo.Input.Keyboards
{
    class KeyDirection: IDirection
    {
        private readonly SFML.Window.Keyboard.Key key;
        private readonly IInput input;

        public KeyDirection(SFML.Window.Keyboard.Key key, IInput input)
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