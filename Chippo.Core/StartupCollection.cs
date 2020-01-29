using System.Collections;
using System.Collections.Generic;
using Chippo.Core.Component;

namespace Chippo.Builder
{
    internal class StartupCollection : ICollection<StartupWrapper>
    {
        private readonly ICollection<StartupWrapper> collectionImplementation = new List<StartupWrapper>();
        public IEnumerator<StartupWrapper> GetEnumerator()
        {
            return collectionImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) collectionImplementation).GetEnumerator();
        }

        public void Add(StartupWrapper item)
        {
            collectionImplementation.Add(item);
        }

        public void Clear()
        {
            collectionImplementation.Clear();
        }

        public bool Contains(StartupWrapper item)
        {
            return collectionImplementation.Contains(item);
        }

        public void CopyTo(StartupWrapper[] array, int arrayIndex)
        {
            collectionImplementation.CopyTo(array, arrayIndex);
        }

        public bool Remove(StartupWrapper item)
        {
            return collectionImplementation.Remove(item);
        }

        public int Count => collectionImplementation.Count;

        public bool IsReadOnly => collectionImplementation.IsReadOnly;
    }
}