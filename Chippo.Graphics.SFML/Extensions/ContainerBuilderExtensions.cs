using Autofac;
using Chippo.Core.Input;
using Chippo.Core.Interfaces;
using Chippo.Graphics.Interface;
using Chippo.Graphics.SFML.Interface;
using Chippo.Graphics.SFML.Strategies;
using SFML.Graphics;
using SFML.Window;

namespace Chippo.Graphics.SFML.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder AddSfml<TDrawable>(this ContainerBuilder builder)
           where TDrawable: IDrawable<SfmlContext>
        {
            builder.RegisterInstance(new RenderWindow(VideoMode.DesktopMode, "test", Styles.None)).SingleInstance();
            builder.RegisterType<SfmlContextFactory>()
                .As<IContextFactory<SfmlContext>>();
            builder.RegisterType<SfmlWindowRenderTarget>()
                .As<IRenderTarget<SfmlContext>>()
                .AsSelf()
                .SingleInstance();
            builder.Register(c => c.Resolve<SfmlWindowRenderTarget>().Input).As<IInput>().SingleInstance();
            builder.RegisterType<SfmlDrawableProvider<TDrawable>>()
                .AsSelf()
                .As<IDrawableProvider<TDrawable,SfmlContext>>()
                .SingleInstance();
          
            builder.RegisterType<BaseRenderStrategy>()
                .As<ISfmlRenderStrategy>()
                .AsSelf();
            return builder;
        }
    }
}