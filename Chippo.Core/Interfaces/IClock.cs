using System;

namespace Chippo.Core.Interfaces
{
    public interface IClock
    {
        void Start();
        TimeSpan Elapsed { get; }
        void Stop();
        bool IsRunning { get; }
    }
}