using System;
using Chippo.Graphics.Interface;

namespace Chippo.GameObjects
{
    public abstract class GameObject
    {
        public delegate void GameObjectDestroyEvent(GameObjectDestroyEventArgs args);
        private TimeSpan last = TimeSpan.Zero;

        public void Update(TimeSpan totalElapsed)
        {
            if (OnUpdate(totalElapsed - last) == GameObjectLifeTime.Destroyed)
            {
                OnDestroy?.Invoke(new GameObjectDestroyEventArgs(this));
            }
            last = totalElapsed;
        }
        protected abstract GameObjectLifeTime OnUpdate(TimeSpan delta);
        public event GameObjectDestroyEvent? OnDestroy;
    }

    public class GameObjectDestroyEventArgs
    {
        public GameObject GameObject { get; }
        public GameObjectDestroyEventArgs(GameObject gameObject)
        {
            GameObject = gameObject;
        }
    }

    public enum GameObjectLifeTime
    {
        Hidden,
        Alive,
        Destroyed
    }

    public abstract class DrawableGameObject<T> : GameObject, IDrawable<T>
    {
        public abstract void Draw(T context);

        public event IDrawable<T>.DrawableDestroyEvent? OnDestroy;
    }
}