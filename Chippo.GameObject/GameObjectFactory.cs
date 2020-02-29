using System;
using System.Collections.Generic;
using Chippo.GameObjects.Interfaces;

namespace Chippo.GameObjects
{
    public class GameObjectFactory : IGameObjectFactory
    {
        private readonly GameState state;
        private Dictionary<string, Func<GameState,GameObject>> factories = new Dictionary<string, Func<GameState, GameObject>>();
        
        public GameObjectFactory(GameState state)
        {
            this.state = state;
        }

        public void Register<T>(Func<GameState, T> factory)
          where T: GameObject
        {
            Register(typeof(T).FullName, factory);
        }

        public void Register(string name, Func<GameState, GameObject> factory)
        {
            factories.Add(name,factory);
        }

        public GameObject Create(string name)
        {
            return factories[name](state);
        }

        public T Create<T>()
            where T: GameObject
        {
            return (T) factories[typeof(T).FullName](state);
        }
    }

}