using System;
using System.Threading.Tasks;
using Chippo.Interfaces;

namespace Chippo
{
    public interface ILoop
    {
        void Start();
        Task<ApplicationState> Next();
        void Stop();
        TimeSpan Elapsed { get; }
        event EventHandler<LoopTickedEventArgs> Ticked;
    }
}