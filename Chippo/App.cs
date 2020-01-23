using Autofac;
using Chippo.Actions;
using Chippo.Actions.Implementation;
using Chippo.Actions.System;
using Chippo.Common;
using Chippo.Constants;
using Chippo.Graphics;
using Chippo.Input;
using Chippo.Settings;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chippo
{
    class App: IEventHandler<IEvent<Guid,string>,Guid,string>
    {
        private readonly IContainer container;
        private readonly IMediator<Guid, string> mediator;
        private string rootScope = "rootScope";
        private RenderWindow window;

        public App(IContainer container, AppSettings settings, IMediator<Guid,string> mediator)
        {
            this.container = container;
            Settings = settings;
            this.mediator = mediator;
        }

        public AppSettings Settings { get; }

        public string Stream => AppConstants.SystemEventStream;

        public Guid Id => QuitEvent.GlobalId;

        public void Configure(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<InputMapper>().As<IInputMapper>().SingleInstance();
            containerBuilder.RegisterType<KeyboardEventFactory>().As<IKeyboardEventFactory<Guid, string>>().SingleInstance();
        }

        public Task Handle(IEvent<Guid,string> @event)
        {
            if(@event.Id == Id && @event.Stream == @event.Stream)
            {
                window.Close();
            }
            return Task.CompletedTask;
        }

        public async Task Start()
        {
            using (var scope = container.BeginLifetimeScope(rootScope, Configure))
            {
                var wb = scope.Resolve<WindowBuilder>();
                window = wb.Build();

                mediator.Subscribe(this);
                var shape = new RectangleShape(new Vector2f(100, 100))
                {
                    FillColor = Color.Black
                };

                while (window.IsOpen)
                {
                    window.DispatchEvents();
                    window.Clear(Color.Cyan);
                    window.Draw(shape);
                    window.Display();
                    await Task.Delay(15);
                }
            }
        }


    }
}
