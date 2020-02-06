using System;

namespace Chippo
{
    public class LoopTickedEventArgs
    {
        public LoopTickedEventArgs(TimeSpan elapsed)
        {
            Elapsed = elapsed;
        }
        public TimeSpan Elapsed { get; }
    }
}