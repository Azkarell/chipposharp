using System;
using System.Diagnostics;
using Chippo.Core.Interfaces;

namespace Chippo.Core
{
    internal class Clock : IClock
    {
        private Stopwatch stopwatch = new Stopwatch();

        public void Start()
        {
            stopwatch.Start();
        }

        public TimeSpan Elapsed => stopwatch.Elapsed;
        public void Stop()
        {
            stopwatch.Stop();
        }

        public bool IsRunning => stopwatch.IsRunning;
    }
}