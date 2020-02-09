using Autofac;
using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    public class ApplicationBuilder
    {
        private readonly ContainerBuilder builder;

        public ApplicationBuilder(ContainerBuilder builder)
        {
            this.builder = builder;
        } 
        public ApplicationBuilder UseStartup<T>() where T : IStartup
        {
            builder.RegisterType<T>().As<IStartup>();
            return this;
        }

        public Application Build()
        {
            var root = builder.Build();
            return new Application(root);
        }
    }
}