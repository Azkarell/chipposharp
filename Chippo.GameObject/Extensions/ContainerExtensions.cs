using System;
using Autofac;
using Chippo.GameObjects.Interfaces;

namespace Chippo.GameObjects.Extensions
{
    public static class ContainerExtensions
    {
        public static ContainerBuilder AddInitialization<T>(this ContainerBuilder builder)
        {
            builder.RegisterType<T>()
                .As<IInitialization>()
                .AsSelf();
            return builder;
        }
    }
}