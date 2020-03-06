using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chippo.GameObjects.Interfaces
{
    public interface ILevel
    {
        Task<ILevel> UpdateAsync(TimeSpan elapsedTime);

        void Add(GameObject gameObject);
        void Remove(GameObject gameObject);
    }

    public abstract class Level : ILevel
    {
        private TimeSpan last = TimeSpan.Zero;

        private List<GameObject> gameObjects = new List<GameObject>();
        public async Task<ILevel> UpdateAsync(TimeSpan elapsedTime)
        {
            var delta = elapsedTime - last;
            var next = await OnUpdate(delta);
            foreach (var gameObject in gameObjects)
            {
                var lifeTime = gameObject.Update(elapsedTime);
                if (lifeTime == GameObjectLifeTime.Destroyed)
                {
                    gameObject.Remove();
                }
            }
            last = elapsedTime;
            return next;
        }

        protected abstract Task<ILevel> OnUpdate(TimeSpan delta);

        public void Add(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
            gameObject.OnRemove(() => Remove(gameObject));
        }

        public void Remove(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

    }
}