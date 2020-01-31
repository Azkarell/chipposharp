using System.Diagnostics;
using System.Threading.Tasks;
using Chippo.Interfaces;

namespace Chippo
{
    public class App
    {
        private readonly IOutput output;
        private readonly IDispatcher dispatcher;
        private readonly ILogic logic;


        public App(IOutput output,IDispatcher dispatcher, ILogic logic)
        {
            this.output = output;
            this.dispatcher = dispatcher;
            this.logic = logic;
        }

        public ApplicationState State { get; private set; } = ApplicationState.Init;

        public async Task Start()
        {
            State = ApplicationState.Running;
            Nito.AsyncEx.AsyncContext.Run(async () =>
            {
                while (State == ApplicationState.Running)
                {
                    dispatcher.DispatchPendingEvents();
                    State = await logic.Update();
                    await output.Update();
                }
                output.Close();
            });
        }
    }
}