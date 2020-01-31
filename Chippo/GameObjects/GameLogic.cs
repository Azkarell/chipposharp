using System.Diagnostics;
using System.Threading.Tasks;
using Chippo.Interfaces;
using SFML.Window;

namespace Chippo.GameObjects
{
    internal class GameLogic: ILogic
    {
        private GameObjectsCollection gameObjects;
        private readonly Stopwatch stopwatch;
        private readonly Input input;

        public GameLogic(GameObjectsCollection gameObjects, Stopwatch stopwatch, Input input)
        {
            this.gameObjects = gameObjects;
            this.stopwatch = stopwatch;
            this.input = input;
        }



        public Task<ApplicationState> Update()
        {
            if (input.IsPressed(Keyboard.Key.Q))
            {
                return Task.FromResult(ApplicationState.Shutdown);
            }
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(stopwatch.Elapsed);
            }
            return Task.FromResult(ApplicationState.Running);
        }
    }
}