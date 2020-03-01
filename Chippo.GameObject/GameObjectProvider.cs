using System.Collections.Generic;
using System.ComponentModel;
using Chippo.Core.Interfaces;
using Chippo.GameObjects.Interfaces;
using NotImplementedException = System.NotImplementedException;

namespace Chippo.GameObjects
{
    public class GameObjectProvider : IGameObjectProvider
    {
        private List<GameObject> gameObjects = new List<GameObject>();

        public void Add(GameObject gameObject)
        {
            gameObject.OnDestroy += OnGameObjectDestroy;
            gameObjects.Add(gameObject);
        }

        private void OnGameObjectDestroy(GameObjectDestroyEventArgs args)
        {
            gameObjects.Remove(args.GameObject);
        }

        public IEnumerable<GameObject> GetGameObjects()
        {
            return gameObjects;
        }
    }
}