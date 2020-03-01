using System.Collections;
using System.Threading.Tasks;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.GameObjects.Interfaces;

namespace Chippo.GameObjects
{
    internal class GameLogic: ILogic
    {
        private readonly ILoop loop;
        private readonly IInput input;
        private readonly IGameObjectProvider gameObjectProvider;

        public GameLogic(ILoop loop,  IInput input, IGameObjectProvider gameObjectProvider)
        {
            this.loop = loop;
            this.input = input;
            this.gameObjectProvider = gameObjectProvider;
        }



        public Task Update()
        {
            if (input.IsPressed(KeyboardKey.Q))
            {
                loop.Stop();
            }
            foreach (var gameObject in gameObjectProvider.GetGameObjects())
            {
                gameObject.Update(loop.Elapsed);
            }
            return Task.CompletedTask;
        }
    }
}