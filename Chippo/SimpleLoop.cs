using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Chippo.Core;
using Chippo.Core.Interfaces;

namespace Chippo
{
    public class SimpleLoop : ILoop
    {
        private readonly IClock clock;
        private readonly LoopOptions options = LoopOptions.Default;
        private TimeSpan last = TimeSpan.Zero;

        public SimpleLoop(IClock clock, LoopOptions? options = null)
        {
            this.clock = clock;
            this.options = options ?? this.options;
        }
        public void Start()
        {
            clock.Start();

        }

        public TimeSpan Elapsed => clock.Elapsed;
        public event EventHandler<LoopTickedEventArgs>? Ticked;

        public async Task<ApplicationState> Next()
        {
            if (!clock.IsRunning)
            {
                return ApplicationState.Shutdown;
            }
            var wait = options.TargetRate - (clock.Elapsed - last);
            if (wait > TimeSpan.Zero)
            {
                await Task.Delay(wait);
            }
            last = clock.Elapsed;
            Ticked?.Invoke(this, e: new LoopTickedEventArgs(last));
            return ApplicationState.Running;
        }

        public void Stop()
        {
            clock.Stop();
        }
    }
}