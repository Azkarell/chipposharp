using Autofac;
using Chippo.Core;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.GameObjects.Extensions;
using Chippo.Graphics.SFML.Extensions;


namespace Chippo
{
    internal class Startup : IStartup
    {
        public void Configure(ContainerBuilder builder)
        {
            builder.AddSfml()
                .AddGameLogic();
        }

        public void ConfigureApp(AppRegistration appRegistration)
        {
            appRegistration
                .UseSfml()
                .UseGameLogic()
                .UseLoop<SimpleLoop>();

        }
    }
}