using System.Threading.Tasks;
using Autofac;
using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    public class Application 
    {
        private readonly ILifetimeScope rootScope;

        internal Application(ILifetimeScope rootScope)
        {
            this.rootScope = rootScope;
        }

        public async Task Start()
        {
            var startup = rootScope.Resolve<IStartup>();
            
            using (var lifetimeScope = rootScope.BeginLifetimeScope(
                b =>
                {
                    var appRegistration = new AppRegistration(b);
                    startup.ConfigureApp(appRegistration);
                    startup.Configure(b);
                }))
            {
                var app = lifetimeScope.Resolve<App>();
                await app.Start();
            }
        }

        public static ApplicationBuilder CreateDefaultApplicationBuilder()
        {
            return new ApplicationBuilder(new ContainerBuilder());

        }
    }
}