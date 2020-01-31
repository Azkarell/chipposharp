using Chippo.Interfaces;
using SFML.Window;

namespace Chippo
{
    public class KeyboardAxis2D: IAxis2D
    {
        private readonly Input input;
        private readonly Keyboard.Key left;
        private readonly Keyboard.Key right;
        private readonly Keyboard.Key up;
        private readonly Keyboard.Key down;

        public KeyboardAxis2D(Input input, Keyboard.Key left, Keyboard.Key right, Keyboard.Key up, Keyboard.Key down)
        {
            this.input = input;
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
        }

        public float XAxis => input.IsPressed(left) ? -1 : 0 + (input.IsPressed(right) ? 1 : 0);
        public float YAxis => input.IsPressed(up) ? -1 : 0 + (input.IsPressed(down) ? 1 : 0);
    }
}