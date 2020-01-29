
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Chippo.Core.Component;
using Microsoft.Extensions.DependencyInjection;
using IStartable = Chippo.Core.Component.IStartable;

namespace Chippo.Builder
{
    public class AppBuilder
    {
        private readonly ContainerBuilder containerBuilder = new ContainerBuilder();
        private List<ComponentRegistration> registrations = new List<ComponentRegistration>();

        public AppBuilder()
        {


        }


        public App Build()
        {
            var container = containerBuilder.Build();
            var startup = container.ResolveOptional<IStartup>();
            var root = container
                .BeginLifetimeScope(b =>
                startup?.ConfigureServices(b));
            var comp = new ComponentCollection();
            var starts = new StartupCollection();
            var shuts = new ShutdownCollection();

            foreach (var registration in registrations)
            {
                registration.Fill(root, comp);
                registration.Fill(root, shuts);
                registration.Fill(root, starts);
            }
            return new App(root, comp, starts, shuts);
        }

        public AppBuilder WithStartUp<T>() where T : IStartup
        {
            containerBuilder.RegisterType<T>().As<IStartup>();
            return this;
        }

        public IComponentRegistration WithComponent<T>() where T : IComponent
        {
            var reg = new ComponentRegistration(containerBuilder, typeof(T));
            reg.RegisterComponent();
            registrations.Add(reg);
            return reg;
        }

        public IComponentRegistration WithComponent<T>(Func<T> factory) where T : IComponent
        {
            var reg = new ComponentRegistrationWithFactory<T>(containerBuilder, factory);
            reg.RegisterComponent();
            registrations.Add(reg);
            return reg;
        }

    }

    public interface IComponentRegistration
    {
        void WithRegistration(Action<ContainerBuilder> register);
    }

    class ComponentRegistration : IComponentRegistration
    {
        protected readonly ContainerBuilder containerBuilder;
        private Type startup;
        private Type shutdown;
        protected Type component;

        public ComponentRegistration(ContainerBuilder containerBuilder, Type component)
        {
            this.containerBuilder = containerBuilder;
            this.component = component;
        }

        public virtual void RegisterComponent()
        {
            containerBuilder.RegisterType(component).AsSelf();
            var gentype = typeof(ComponentWrapper<>).MakeGenericType(component);
            containerBuilder.RegisterType(gentype);
        }


        public void WithRegistration(Action<ContainerBuilder> register)
        {
            register(containerBuilder);
        }



        private void Fill<T>(ILifetimeScope scope, ICollection<T> collection, Type type)
        {
            var comp = (T)scope.Resolve(type);
            collection.Add(comp);
        }

        public void Fill(ILifetimeScope scope, ComponentCollection components)
        {
            var gentype = typeof(ComponentWrapper<>).MakeGenericType(component);
            Fill(scope, components, gentype);
        }

        public void Fill(ILifetimeScope scope, ShutdownCollection shutdownCollection)
        {
            if (shutdown != null)
            {
                var gentype = typeof(ShutdownWrapper<>).MakeGenericType(shutdown);
                Fill(scope, shutdownCollection, gentype);

            }
        }

        public void Fill(ILifetimeScope scope, StartupCollection startupCollection)
        {
            if (startup != null)
            {
                var gentype = typeof(StartupWrapper<>).MakeGenericType(startup);
                Fill(scope, startupCollection, gentype);
            }
        }
    }

    class ComponentRegistrationWithFactory<T> : ComponentRegistration
    {
        private readonly Func<T> factory;

        public ComponentRegistrationWithFactory(ContainerBuilder containerBuilder, Func<T> factory) : base(containerBuilder, typeof(T))
        {
            this.factory = factory;
        }

        public override void RegisterComponent()
        {
            containerBuilder.Register(c => factory());
            var gentype = typeof(ComponentWrapper<>).MakeGenericType(component);
            containerBuilder.RegisterType(gentype);
        }
    }
}
