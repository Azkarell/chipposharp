using System;

namespace Chippo
{
    public struct LoopOptions
    {
        public TimeSpan TargetRate { get; private set; }

        public static LoopOptions Default { get; } = new LoopOptions
        {
            TargetRate = TimeSpan.FromMilliseconds(16)
        };
    }
}