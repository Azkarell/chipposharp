using System.Collections;
using System.Collections.Generic;
using Chippo.EventSystem.Abstraction;

namespace Chippo.EventSystem
{
    internal class EventRegistrationCollection: ICollection<EventRegistration>
    {
        private List<EventRegistration> _types = new List<EventRegistration>();
        public IEnumerator<EventRegistration> GetEnumerator()
        {
            return _types.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _types).GetEnumerator();
        }

        public void Add(EventRegistration item)
        {
            _types.Add(item);
        }

        public void Clear()
        {
            _types.Clear();
        }

        public bool Contains(EventRegistration item)
        {
            return _types.Contains(item);
        }

        public void CopyTo(EventRegistration[] array, int arrayIndex)
        {
            _types.CopyTo(array, arrayIndex);
        }

        public bool Remove(EventRegistration item)
        {
            return _types.Remove(item);
        }

        public int Count => _types.Count;

        public bool IsReadOnly => ((ICollection<EventRegistration>) _types).IsReadOnly;
    }
}