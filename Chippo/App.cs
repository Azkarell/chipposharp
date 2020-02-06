using System.Diagnostics;
using System.Threading.Tasks;
using Chippo.GameObjects;
using Chippo.Interfaces;

namespace Chippo
{
    public class App
    {
        private readonly IOutput output;
        private readonly IDispatcher dispatcher;
        private readonly ILogic logic;
        private readonly ILoop loop;


        public App(IOutput output,IDispatcher dispatcher, ILogic logic, ILoop loop)
        {
            this.output = output;
            this.dispatcher = dispatcher;
            this.logic = logic;
            this.loop = loop;
        }

        public ApplicationState State { get; private set; } = ApplicationState.Init;

        public async Task Start()
        {
            State = ApplicationState.Running;
            loop.Start();
            Nito.AsyncEx.AsyncContext.Run(async () =>
            {
                while (State == ApplicationState.Running && output.IsOpen)
                {
                    dispatcher.DispatchPendingEvents();
                    await logic.Update();
                    await output.Update();
                    State = await loop.Next();
                }
                output.Close();
            });
        }
    }
}