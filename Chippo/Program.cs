using Chippo.Builder;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Threading.Tasks;
using Chippo.Graphics;

namespace Chippo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new AppBuilder();
            builder
                .WithStartUp<Startup>()
                .WithComponent<Graphics2D>()
            var app = builder.Build();
            app.Start();
        }


    }
}
