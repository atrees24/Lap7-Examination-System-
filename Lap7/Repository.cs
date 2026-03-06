using System;
using System.Collections.Generic;
using System.Text;

namespace Lap7
{
    public class Repository<T> where T : ICloneable, IComparable<T>
    {
        private List<T> _items;

        public Repository()
        {
            _items = new List<T>();
        }

        public void Add(T item)
        {
            if(item == null) 
                throw new ArgumentNullException(nameof(item));

            _items.Add(item);
        }

        public void Remove(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            bool removed = _items.Remove(item);
            if (!removed)
                throw new InvalidOperationException("Item not found.");
        }

        public void Sort()
        {
            _items.Sort();
        }

       
        public List<T> GetAll()
        {
            return new List<T>(_items);
        }


    }
}
