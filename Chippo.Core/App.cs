using System;
using System.Threading.Tasks;
using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    public class App 
    {
        private readonly IOutput output;
        private readonly IDispatcher dispatcher;
        private readonly ILogic logic;
        private readonly ILoop loop;


        public App(IOutput output, IDispatcher dispatcher, ILogic logic, ILoop loop)
        {
            this.output = output;
            this.dispatcher = dispatcher;
            this.logic = logic;
            this.loop = loop;
        }

        public ApplicationState State { get; private set; } = ApplicationState.Init;

        public Task Start()
        {
            State = ApplicationState.Running;
            Nito.AsyncEx.AsyncContext.Run(async () =>
            {
                await logic.Initialize();
                loop.Start();
                while (State == ApplicationState.Running && output.IsOpen)
                {
                    await dispatcher.DispatchPendingEvents();
                    await logic.Update();
                    await output.Update();
                    State = await loop.Next();
                }
                await logic.Shutdown();
                output.Close();
            });
            return Task.CompletedTask;
        }
    }
}