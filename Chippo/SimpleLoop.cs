using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Chippo.Interfaces;

namespace Chippo
{
    public class SimpleLoop : ILoop
    {
        private readonly Stopwatch stopwatch;
        private readonly TimeSpan targetRate;
        private TimeSpan last = TimeSpan.Zero;

        public SimpleLoop(Stopwatch stopwatch, TimeSpan targetRate)
        {
            this.stopwatch = stopwatch;
            this.targetRate = targetRate;
        }
        public void Start()
        {
            stopwatch.Start();

        }

        public TimeSpan Elapsed => stopwatch.Elapsed;
        public event EventHandler<LoopTickedEventArgs> Ticked;

        public async Task<ApplicationState> Next()
        {
            if (!stopwatch.IsRunning)
            {
                return ApplicationState.Shutdown;
            }
            var wait = targetRate - (stopwatch.Elapsed - last);
            if (wait > TimeSpan.Zero)
            {
                await Task.Delay(wait);
            }
            last = stopwatch.Elapsed;
            Ticked?.Invoke(this,e: new LoopTickedEventArgs(last));
            return ApplicationState.Running;
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
    }
}