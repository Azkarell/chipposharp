using System;
using System.Collections.Generic;
using Chippo.GameObjects.Interfaces;

namespace Chippo.GameObjects
{
    public class GameObjectFactory : IGameObjectFactory
    {
        private readonly GameObjectProvider gameObjectProvider;
        private Dictionary<string, Func<GameObject>> factories = new Dictionary<string, Func<GameObject>>();
        
        public GameObjectFactory(GameObjectProvider gameObjectProvider )
        {
            this.gameObjectProvider = gameObjectProvider;
        }

        public void Register<T>(Func<T> factory)
          where T: GameObject
        {
            Register(typeof(T).FullName, factory);
        }

        public void Register(string name, Func<GameObject> factory)
        {
            factories.Add(name,factory);
        }

        public GameObject Create(string name)
        {
            var go = factories[name]();
            gameObjectProvider.Add(go);
            return go;
        }

        public T Create<T>()
            where T: GameObject
        {
            return (T) Create(typeof(T).FullName);
        }
    }

}