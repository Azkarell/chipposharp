using System;
using System.Threading.Tasks;

namespace Chippo.Core.Interfaces
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