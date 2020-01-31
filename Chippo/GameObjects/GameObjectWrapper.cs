using System;
using System.Diagnostics;

namespace Chippo.GameObjects
{
    public class GameObjectWrapper: GameObject {
        private readonly GameObject actualObject;
        private readonly Stopwatch stopwatch;
        private TimeSpan last;

        public GameObjectWrapper(GameObject actualObject, Stopwatch stopwatch)
        {
            this.actualObject = actualObject;
            this.stopwatch = stopwatch;
            last = stopwatch.Elapsed;
        }
        public override void Update(TimeSpan delta)
        {
            actualObject.Update(stopwatch.Elapsed - last);
            last = stopwatch.Elapsed;
        }
    }
}