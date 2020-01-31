using System;

namespace Chippo.GameObjects
{
    public abstract class GameObject
    {
        public abstract void Update(TimeSpan delta);
    }
}