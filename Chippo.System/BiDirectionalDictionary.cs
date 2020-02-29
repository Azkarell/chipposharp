using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Chippo.System
{
    public class BiDirectionalDictionary<T1, T2>
    {
        private Dictionary<int, TwoWayKeyValue<T1, T2>> valueDictionary = new Dictionary<int, TwoWayKeyValue<T1, T2>>();
        private Dictionary<int, int> lookupDictionary = new Dictionary<int, int>();

        public T1 this[T2 t2]
        {
            get => Lookup(t2);
            set => Insert(value, t2);
        }

        public T2 this[T1 t1]
        {
            get => Lookup(t1);
            set => Insert(t1, value);
        }

        private void Insert(T1 t1, T2 t2)
        {
            var hash1 = t1.GetHashCode();
            var hash2 = t2.GetHashCode();
            var combined = hash1 | hash2 ;
            if (lookupDictionary.ContainsKey(hash1))
            {
                valueDictionary.Remove(lookupDictionary[hash1]);
            }

            if (lookupDictionary.ContainsKey(hash2))
            {
                valueDictionary.Remove(lookupDictionary[hash2]);
            }
            lookupDictionary[hash1] = combined;
            lookupDictionary[hash2] = combined;
            valueDictionary[combined] = new TwoWayKeyValue<T1, T2>(t1, t2);
        }

        private T1 Lookup(T2 t2)
        {
            var hash = t2.GetHashCode();
            var combined = lookupDictionary[hash];
            return valueDictionary[combined].First;
        }

        private T2 Lookup(T1 t1)
        {
            var hash = t1.GetHashCode();
            var combined = lookupDictionary[hash];
            return valueDictionary[combined].Second;
        }

        class TwoWayKeyValue<T1, T2>
        {
            public T1 First { get; }
            public T2 Second { get; }


            public TwoWayKeyValue(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }


        }
    }
}
