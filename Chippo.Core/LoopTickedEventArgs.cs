using System;

namespace Chippo.Core
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