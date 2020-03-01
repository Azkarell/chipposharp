using Autofac;
using Chippo.GameObjects.Interfaces;

namespace Chippo.GameObjects.Extensions
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder AddGameLogic(this ContainerBuilder builder)
        {
            builder.RegisterType<GameObjectProvider>()
                .AsSelf()
                .As<IGameObjectProvider>()
                .SingleInstance();
            return builder;
        }
    }
}