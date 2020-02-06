using System.Diagnostics;
using System.Threading.Tasks;
using Chippo.Input;
using Chippo.Interfaces;
using SFML.Window;

namespace Chippo.GameObjects
{
    internal class GameLogic: ILogic
    {
        private readonly ILoop loop;
        private readonly GameState state;
        private readonly IInput input;

        public GameLogic(ILoop loop, GameState state, IInput input)
        {
            this.loop = loop;
            this.state = state;
            this.input = input;
        }



        public Task Update()
        {
            if (input.IsPressed(Keyboard.Key.Q))
            {
                loop.Stop();
            }
            foreach (var gameObject in state.GameObjects)
            {
                gameObject.Update(loop.Elapsed);
            }
            return Task.CompletedTask;
        }
    }
}