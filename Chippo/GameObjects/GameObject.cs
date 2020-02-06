using System;

namespace Chippo.GameObjects
{

    public abstract class StaticObject
    {
        
    }

    public abstract class GameObject
    {
        private TimeSpan last = TimeSpan.Zero;

        public void Update(TimeSpan totalElapsed)
        {
            OnUpdate(totalElapsed - last);
            last = totalElapsed;
        }
        protected abstract void OnUpdate(TimeSpan delta);
    }
}