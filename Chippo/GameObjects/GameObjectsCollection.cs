using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SFML.Graphics;

namespace Chippo.GameObjects
{
    internal class GameObjectsCollection: ICollection<GameObject>, IEnumerable<Drawable>
    {
        private readonly Stopwatch sharedStopwatch;
        private ICollection<GameObject> gameObjectsImplementation = new List<GameObject>();
        private List<Drawable> drawablesImplementation = new List<Drawable>();

        public GameObjectsCollection(Stopwatch sharedStopwatch)
        {
            this.sharedStopwatch = sharedStopwatch;
        }


        IEnumerator<Drawable> IEnumerable<Drawable>.GetEnumerator()
        {
            return drawablesImplementation.GetEnumerator();
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            return gameObjectsImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) gameObjectsImplementation).GetEnumerator();
        }

        public void Add(GameObject item)
        {
            gameObjectsImplementation.Add(new GameObjectWrapper(item, sharedStopwatch));
            if (item is DrawableGameObject drawableGameObject)
            {
                drawablesImplementation.Add(drawableGameObject.AsDrawable);
            }
        }

   

        public void Clear()
        {
            gameObjectsImplementation.Clear();
            drawablesImplementation.Clear();
        }


        public bool Contains(GameObject item)
        {
            return gameObjectsImplementation.Contains(item);
        }

        public void CopyTo(GameObject[] array, int arrayIndex)
        {
            gameObjectsImplementation.CopyTo(array, arrayIndex);
        }

        public bool Remove(GameObject item)
        {
            if (item is DrawableGameObject drawableGameObject)
            {
                drawablesImplementation.Remove(drawableGameObject.AsDrawable);
            }
            return gameObjectsImplementation.Remove(item);
        }

        public int Count => gameObjectsImplementation.Count;

        public bool IsReadOnly => gameObjectsImplementation.IsReadOnly;
    }
}