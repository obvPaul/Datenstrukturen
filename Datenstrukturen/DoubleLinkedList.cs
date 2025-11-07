using System;
using Common;

namespace Datenstrukturen
{
    public class DoubleLinkedList<T>
    {
        private DoubleNode<T>? head = null;
        private DoubleNode<T>? tail = null;

        public DoubleNode<T> InsertAtEnd(T element)
        {
            var newNode = new DoubleNode<T>(element);

            if (head == null)
            {
                head = tail = newNode;
                return head;
            }

            tail!.Next = newNode;
            newNode.Prev = tail;
            tail = newNode;
            return tail;
        }

        public DoubleNode<T>? SearchNode(Func<T, bool> predicate)
        {
            var current = head;
            while (current != null)
            {
                if (predicate(current.Data))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void InsertBefore(T elementAfter, T elementToInsert, Func<T, T, bool> comparer)
        {
            var current = head;
            while (current != null && !comparer(current.Data, elementAfter))
            {
                current = current.Next;
            }

            if (current == null) return;

            var newNode = new DoubleNode<T>(elementToInsert);
            newNode.Next = current;
            newNode.Prev = current.Prev;

            if (current.Prev != null)
                current.Prev.Next = newNode;
            else
                head = newNode;

            current.Prev = newNode;
        }

        public void InsertAfter(T elementBefore, T elementToInsert, Func<T, T, bool> comparer)
        {
            var current = head;
            while (current != null && !comparer(current.Data, elementBefore))
            {
                current = current.Next;
            }

            if (current == null) return;

            var newNode = new DoubleNode<T>(elementToInsert);
            newNode.Prev = current;
            newNode.Next = current.Next;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                tail = newNode;

            current.Next = newNode;
        }

        public DoubleNode<T>? GetHead() => head;
        public DoubleNode<T>? GetTail() => tail;
    }
}
