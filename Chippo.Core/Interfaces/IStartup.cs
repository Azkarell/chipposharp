using Autofac;

namespace Chippo.Core.Interfaces
{
    public interface IStartup
    {
        void Configure(ContainerBuilder builder);
        void ConfigureApp(AppRegistration appRegistration);
    }
}