using System;

namespace Chippo.Core
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