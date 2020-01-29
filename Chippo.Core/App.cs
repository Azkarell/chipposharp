
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Chippo.Builder;
using Chippo.Core.Component;
using Microsoft.Extensions.DependencyInjection;

namespace Chippo
{
    public class App: IDisposable
    {
        private readonly ILifetimeScope scope;
        private readonly ComponentCollection components;
        private readonly StartupCollection startups;
        private readonly ShutdownCollection shutdowns;

        internal App(ILifetimeScope scope,
            ComponentCollection components,
            StartupCollection startups,
            ShutdownCollection shutdowns)
        {
            this.scope = scope;
            this.components = components;
            this.startups = startups;
            this.shutdowns = shutdowns;
        }
        
        public void Start()
        {
            State = ApplicationState.Running;
            foreach (var startup in startups)
            {
                startup.Start();
            }
            while (State == ApplicationState.Running)
            {
                var stopwatch = new Stopwatch();
                foreach (var component in components)
                {
                    State = component.Update(stopwatch.Elapsed);
                }
            }
        }

        public void Exit()
        {
            State = ApplicationState.Shutdown;
            foreach (var component in shutdowns)
            {
                component.Shutdown();
            }
        }

        public ApplicationState State { get; set; } = ApplicationState.Init;

        public void Dispose()
        {
            scope.Dispose();
        }
    }
}
