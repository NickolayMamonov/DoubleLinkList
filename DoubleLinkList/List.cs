using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using DoubleLinkList;

namespace List
{
    public class List<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public int Count { get; protected set; }

        public bool IsEmpty() => Count == 0;
        
        public void Add(T value)
        {
            Node<T> Node = new Node<T>(value);

            if (head is null)
            {
                head = Node;
            }
            else
            {
                tail.Next = Node;
                Node.Previous = tail;
            }

            tail = Node;
            Count++;
        }
        public void Delete(int num)
        {
            Node<T> CurrentNode = head;
            int CurrentNum = 0;
            while (CurrentNum != num)
            {
                CurrentNode = CurrentNode.Next;
                CurrentNum++;
                if (CurrentNode == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            if (CurrentNode.Previous == null)
            {
                head = CurrentNode.Next;
            }
            else if (CurrentNode.Next == null)
            {
                CurrentNode.Previous.Next = null;
                tail = CurrentNode.Previous;
            }
            else
            {
                CurrentNode.Previous.Next = CurrentNode.Next;
                CurrentNode.Next.Previous = CurrentNode.Previous;
            }

            Count--;
        }

        public T this[int num]
        {
            get { return Get(num); }
            set
            {
                T input = value;
                Node<T> CurrentNode = head;
                int CurrentNum = 0;
                while (CurrentNum != num)
                {
                    CurrentNode = CurrentNode.Next;
                    CurrentNum++;
                    if (CurrentNode == null)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }

                CurrentNode.Value = input;
            }
        } 

        public T Get(int num)
        {
            Node<T> CurrentNode = head;
            int CurrentNum = 0;
            while (CurrentNum != num)
            {
                CurrentNode = CurrentNode.Next;
                CurrentNum++;
                if (CurrentNode == null)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            return CurrentNode.Value;
        }
        

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> CurrentNode = head;
            while (CurrentNode != null)
            {
                yield return CurrentNode.Value;
                CurrentNode = CurrentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

       /* public IEnumerable<T> BackEnumerator()
        {
            Node<T> CurrentNode = tail;
            while (CurrentNode != null)
            {
                yield return CurrentNode.Value;
                CurrentNode = CurrentNode.Previous;
            }
        }*/
    }
}