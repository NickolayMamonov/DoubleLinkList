using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace DoubleLinkList
{
    public class Stack<T> : IEnumerable<T>
    {
        private T[] _items;
        public int Size { get; protected set; }
        public int Cap { get; protected set; } 
        private const int _defaultCap = 5;

        public Stack()
        {
            Cap = _defaultCap;
            _items = new T[Cap];
            Size = 0;
        }

        public Stack(int length)
        {
            if (length > 0)
            {
                _items = new T[length];
                Cap = length;
                Size = 0;
            }
            else
            {
                throw new InvalidEnumArgumentException($"length = '{length}' is not correct argument");
            }
            
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Add(T item)
        {
            if (Size == _items.Length)
            {
                T[] temp = _items;
                Cap = _items.Length * 2;
                _items = new T[Cap];
                for (int i = 0; i < Size; i++)
                {
                    _items[i] = temp[i];
                }

                _items[Size++] = item;
            }
            else
            {
                _items[Size++] = item;
            }
        }

        public T this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public T Remove()
        {
            T removed = default(T);
            if (!IsEmpty())
            {
                removed = _items[Size];
                Size--;
            }
            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int index = Size - 1;
            T CurrentNode = default(T);
            while (index > -1)
            {
                CurrentNode = _items[index];
                index--;
                yield return CurrentNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}