using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chippo.EventSystem
{
    internal class HandlerCollection: ICollection<Type>
    {
        private readonly Type handlerType;

        public HandlerCollection(Type handlerType)
        {
            this.handlerType = handlerType;
        }
        private List<Type> handler = new List<Type>();
        public IEnumerator<Type> GetEnumerator()
        {
            return handler.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) handler).GetEnumerator();
        }

        public void Add(Type item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (item.GetInterfaces().Contains(handlerType))
            {
                handler.Add(item);
            } 
            throw new ArgumentException(item.FullName + " can't be used as a handler");
        }

        public void Clear()
        {
            handler.Clear();
        }

        public bool Contains(Type item)
        {
            return handler.Contains(item);
        }

        public void CopyTo(Type[] array, int arrayIndex)
        {
            handler.CopyTo(array, arrayIndex);
        }

        public bool Remove(Type item)
        {
            return handler.Remove(item);
        }

        public int Count => handler.Count;

        public bool IsReadOnly => ((ICollection<Type>) handler).IsReadOnly;
    }
}