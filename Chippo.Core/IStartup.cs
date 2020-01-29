using Autofac;

namespace Chippo.Builder
{
    public interface IStartup
    {
        void ConfigureServices(ContainerBuilder containerBuilder);

    }
}