using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Principal;
using Autofac;
using Autofac.Core.Registration;
using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    public class AppRegistration
    {
        private ContainerBuilder builder;

        public AppRegistration(ContainerBuilder containerBuilder)
        {
            builder = containerBuilder;
            builder.RegisterType<App>();
            builder.RegisterType<Clock>()
                .As<IClock>()
                .SingleInstance();
        }


        public AppRegistration UseOutput<T, TContext>() where T : IOutput<TContext>
        {
            builder.RegisterType<TContext>()
                .AsSelf();
            builder.RegisterType<T>()
                .As<IOutput<TContext>>()
                .AsSelf()
                .SingleInstance();

            builder.RegisterType<Output<TContext>>()
                .As<Output>()
                .AsSelf()
                .SingleInstance();
            return this;
        }

        public AppRegistration UseLogic<T>() where T : ILogic
        {
            builder.RegisterType<T>()
                .As<ILogic>()
                .AsSelf()
                .SingleInstance();
            return this;
        }

        public AppRegistration UseLoop<T>() where T : ILoop
        {
            builder.RegisterType<T>()
                .As<ILoop>()
                .AsSelf()
                .SingleInstance();
            return this;
        }

        public AppRegistration UseDispatcher<T>() where T : IDispatcher
        {
            builder.RegisterType<T>()
                .As<IDispatcher>()
                .AsSelf()
                .SingleInstance();
            return this;
        }

    }
}