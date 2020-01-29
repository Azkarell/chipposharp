using System.Collections;
using System.Collections.Generic;

namespace Chippo.Core.Component
{
    internal class ComponentCollection: ICollection<ComponentWrapper>
    {
        private readonly List<ComponentWrapper> data = new List<ComponentWrapper>();

        public IEnumerator<ComponentWrapper> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) data).GetEnumerator();
        }

        public void Add(ComponentWrapper item)
        {
            data.Add(item);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(ComponentWrapper item)
        {
            return data.Contains(item);
        }

        public void CopyTo(ComponentWrapper[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public bool Remove(ComponentWrapper item)
        {
            return data.Remove(item);
        }

        public int Count => data.Count;

        public bool IsReadOnly => ((ICollection<ComponentWrapper>) data).IsReadOnly;
    }
}