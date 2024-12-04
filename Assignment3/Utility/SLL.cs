using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        private Node Head;
        private int Size;

        public SLL()
        {
            Head = null;
            Size = 0;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > Size) throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            var current = Head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            var newNode = new Node(value) { Next = current.Next };
            current.Next = newNode;
            Size++;
        }

        public void AddFirst(User value)
        {
            var newNode = new Node(value) { Next = Head };
            Head = newNode;
            Size++;

        }

        public void AddLast(User value)
        {
            var newNode = new Node(value);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                var current = Head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Size++;
        }

        public void Clear()
        {
            Head = null;
            Size = 0;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        public int Count() => Size;

        public User GetValue(int index)
        {
            if (index < 0 || index >= Size) throw new IndexOutOfRangeException();

            var current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.User;
        }

        public int IndexOf(User value)
        {
            var current = Head;
            for (int i = 0; i < Size; i++)
            {
                if (current.User.Equals(value)) return i;
                current = current.Next;
            }
            return -1;
        }

        public bool IsEmpty() => Size == 0;

        public void Remove(int index)
        {
            if (index < 0 || index >= Size) throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            var current = Head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            Size--;
        }

        public void RemoveFirst()
        {
            if (IsEmpty()) throw new InvalidOperationException("Cannot remove from an empty list.");
            Head = Head.Next;
            Size--;
        }

        public void RemoveLast()
        {
            if (IsEmpty()) throw new InvalidOperationException("Cannot remove from an empty list.");
            if (Head.Next == null)
            {
                Head = null;
            }
            else
            {
                var current = Head;
                while (current.Next != null && current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
            Size--;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= Size) throw new IndexOutOfRangeException();

            var current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.User = value;
        }

        public void Reverse()
        {
            Node prev = null;
            Node current = Head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            Head = prev;
        }
    }
}
