using Autofac;
using Chippo.Core;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.GameObjects;
using Chippo.SFML;
using Chippo.SFML.Extensions;
using SFML.Graphics;
using SFML.Window;

namespace Chippo
{
    internal class Startup : IStartup
    {
        public void Configure(ContainerBuilder builder)
        {
            builder.RegisterType<Clock>().As<IClock>().SingleInstance();
            builder.RegisterType<GameState>().SingleInstance();
            builder.AddSfml();
        }

        public void ConfigureApp(AppRegistration appRegistration)
        {
            appRegistration
                .UseSfml()
                .UseLogic<GameLogic>()
                .UseLoop<SimpleLoop>();

        }
    }
}