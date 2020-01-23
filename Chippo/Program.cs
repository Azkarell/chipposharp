using Chippo.Builder;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Threading.Tasks;

namespace Chippo
{
    class Program
    {
        static void Main(string[] args)
        {
            Nito.AsyncEx.AsyncContext.Run(
                async () =>
                {
                    var builder = new AppBuilder();
                    var app = builder.Build();
                    await app.Start();
                });
          
        }

  
    }
}
