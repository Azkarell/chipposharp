using Autofac;
using Chippo.Core.Input;
using SFML.Graphics;
using SFML.Window;

namespace Chippo.SFML.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddSfml(this ContainerBuilder builder)
        {
            builder.RegisterInstance(new RenderWindow(VideoMode.DesktopMode, "test", Styles.None)).SingleInstance();
            builder.Register(c => c.Resolve<SfmlWindow>().Input).As<IInput>().SingleInstance();
            return builder;
        }
    }
}