using Autofac;
using Chippo.Core;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.GameObjects;
using Chippo.GameObjects.Extensions;
using Chippo.Graphics;
using Chippo.Graphics.SFML;
using Chippo.Graphics.SFML.Extensions;
using SFML.Graphics;
using NotImplementedException = System.NotImplementedException;


namespace Chippo
{
    internal class Startup : IStartup
    {
        public void Configure(ContainerBuilder builder)
        {
            builder
                .AddSfml<DrawableGameObject<SfmlContext>>()
                .AddInitialization<Initialization>();
        }

        public void ConfigureApp(AppRegistration appRegistration)
        {
            appRegistration
                .UseSfml<DrawableGameObject<SfmlContext>>()
                .UseGameLogic()
                .UseLoop<SimpleLoop>();

        }


    }
}