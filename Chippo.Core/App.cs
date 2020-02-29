using System;
using System.Threading.Tasks;
using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    public class App 
    {
        private readonly Output output;
        private readonly IDispatcher dispatcher;
        private readonly ILogic logic;
        private readonly ILoop loop;


        public App(Output output,IDispatcher dispatcher, ILogic logic, ILoop loop)
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
                loop.Start();
                while (State == ApplicationState.Running && output.IsOpen)
                {
                    await dispatcher.DispatchPendingEvents();
                    await logic.Update();
                    await output.Update();
                    State = await loop.Next();
                }
                output.Close();
            });
            return Task.CompletedTask;
        }
    }
}