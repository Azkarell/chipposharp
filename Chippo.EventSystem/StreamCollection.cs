using System.Collections;
using System.Collections.Generic;
using Chippo.EventSystem.Abstraction;

namespace Chippo.EventSystem
{
    internal class StreamCollection: ICollection<StreamRegistration>
    {
        private List<StreamRegistration> registrations = new List<StreamRegistration>();
        public StreamCollection()
        {

        }

        public IEnumerator<StreamRegistration> GetEnumerator()
        {
            return registrations.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) registrations).GetEnumerator();
        }

        public void Add(StreamRegistration item)
        {
            registrations.Add(item);
        }

        public void Clear()
        {
            registrations.Clear();
        }

        public bool Contains(StreamRegistration item)
        {
            return registrations.Contains(item);
        }

        public void CopyTo(StreamRegistration[] array, int arrayIndex)
        {
            registrations.CopyTo(array, arrayIndex);
        }

        public bool Remove(StreamRegistration item)
        {
            return registrations.Remove(item);
        }

        public int Count => registrations.Count;

        public bool IsReadOnly => ((ICollection<StreamRegistration>) registrations).IsReadOnly;
    }
}