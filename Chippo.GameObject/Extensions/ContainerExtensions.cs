using Autofac;

namespace Chippo.GameObjects.Extensions
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder AddGameLogic(this ContainerBuilder builder)
        {
            builder.RegisterType<GameState>()
                .AsSelf()
                .SingleInstance();
            return builder;
        }
    }
}