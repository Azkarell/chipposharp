using System.Collections.Generic;
using SFML.Graphics;
using SFML.Window;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Chippo.GameObjects;
using Chippo.Interfaces;

namespace Chippo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new AppBuilder();
            var app = builder.Build();
            await app.Start();
        }
    }
}
