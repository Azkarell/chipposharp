using Autofac;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.Graphics.Interface;
using SFML.Graphics;
using SFML.Window;

namespace Chippo.Graphics.SFML.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddSfml(this ContainerBuilder builder)
        {
            builder.RegisterInstance(new RenderWindow(VideoMode.DesktopMode, "test", Styles.None)).SingleInstance();
            builder.RegisterType<SfmlContextFactory>()
                .As<IContextFactory<SfmlContext>>();
            builder.Register(c => c.Resolve<SfmlGraphics2D>().Input).As<IInput>().SingleInstance();
            builder.RegisterType<SfmlDrawableProvider>()
                .AsSelf()
                .As<IDrawableProvider<SfmlContext>>()
                .SingleInstance();

            return builder;
        }
    }
}