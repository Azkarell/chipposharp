using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Chippo.Core;

namespace Chippo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var app = CreateApplication();
            await app.Start();
        }

        static Application CreateApplication()
        {
            return Application.CreateDefaultApplicationBuilder()
                .UseStartup<Startup>()
                .Build();
        }
    }
}
