using Autofac;
using Chippo.Actions;
using Chippo.Actions.Implementation;
using Chippo.Common;
using Chippo.Graphics;
using Chippo.Settings;
using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chippo.Builder
{
    class AppBuilder
    {
        private ContainerBuilder _containerBuilder = new ContainerBuilder();
        
        public AppBuilder()
        {
            _containerBuilder.RegisterType<DefaultSettingProvider>().As<ISettingsProvider>().SingleInstance();
            _containerBuilder.Register((c) => c.Resolve<ISettingsProvider>().GetSettings()).InstancePerDependency();
            _containerBuilder.Register((c) => c.Resolve<ISettingsProvider>().GetSettings().InputSettings).InstancePerDependency();
            _containerBuilder.RegisterType<Mediator>().As<IMediator<Guid, string>>().SingleInstance();
            _containerBuilder.RegisterType<WindowBuilder>().AsSelf().InstancePerDependency();
            _containerBuilder.RegisterType<CloneService>().As<ICloneService>();

        }

        public AppBuilder UseSettings(ISettingsProvider settingsProvider)
        {
            _containerBuilder.RegisterInstance(settingsProvider).As<ISettingsProvider>().SingleInstance();
            return this;
        }

        public AppBuilder ConfigureRootServices(Action<ContainerBuilder> configure)
        {
            configure(_containerBuilder);
            return this;
        }

        public App Build()
        {
            var container = _containerBuilder.Build();
            var settings = container.Resolve<AppSettings>();
            var mediator = container.Resolve<IMediator<Guid, string>>();
            return new App(container,settings,mediator);
        }
    }
}
