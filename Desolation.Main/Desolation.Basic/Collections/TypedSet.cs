using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Desolation.Basic.Collections
{
    public class TypedSet<T> : IEnumerable<T>
    {
        protected readonly ICollection<T> Items;

        public TypedSet()
        {
            Items = new List<T>();
        }
        
        public void Insert(T item)
        {
            if (Items.Any(n => n.GetType() == item.GetType()))
                throw new Exception($"Collection already contains an item of type {item.GetType()}");

            Items.Add(item);
        }
        
        public bool Contains<U>()
        {
            return Items.Any(n => n.GetType() == typeof(U));
        }
        
        public U Get<U>() where U : T
        {
            return (U)Items.FirstOrDefault(item => item is U);
        }

        public void Remove(T item)
        {
            Items.Remove(item);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}