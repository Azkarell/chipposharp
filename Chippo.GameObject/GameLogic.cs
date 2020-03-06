using System.Collections;
using System.Threading.Tasks;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.GameObjects.Interfaces;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.GameObjects
{
    public class GameLogic: ILogic
    {
        private readonly IInitialization initialization;
        private readonly IClock clock;
        public ILevel CurrentLevel { get; private set; }

        public GameLogic(IInitialization initialization, IClock clock)
        {
            this.initialization = initialization;
            this.clock = clock;
        }


        public async Task Initialize()
        {
            CurrentLevel = await initialization.InitializeAsync();
        }
        public async Task Update()
        {
            if (CurrentLevel == null)
            {
                clock.Stop();
            }
            if (clock.IsRunning)
            {
                CurrentLevel = await CurrentLevel.UpdateAsync(clock.Elapsed);
            }
        }

        public Task Shutdown()
        {
            return Task.CompletedTask;
        }



    }


}