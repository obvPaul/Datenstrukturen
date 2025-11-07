using System;
using Common;

namespace Datenstrukturen
{
    public class DoubleLinkedList<T>
    {
        private Node<T>? head = null;
        private Node<T>? tail = null;

        public Node<T> InsertAtEnd(T element)
        {
            var newNode = new Node<T>(element);

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

        public Node<T>? SearchNode(Func<T, bool> predicate) 
        {
            var current = head;
            while (current != null)
            {
                if (predicate(current.data))
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void InsertBefore(T elementAfter, T elementToInsert, Func<T, T, bool> comparer)
        {
            var current = head;
            while (current != null && !comparer(current.data, elementAfter))
            {
                current = current.Next;
            }

            if (current == null) return;

            var newNode = new Node<T>(elementToInsert);
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
            while (current != null && !comparer(current.data, elementBefore))
            {
                current = current.Next;
            }

            if (current == null) return;

            var newNode = new Node<T>(elementToInsert);
            newNode.Prev = current;
            newNode.Next = current.Next;

            if (current.Next != null)
                current.Next.Prev = newNode;
            else
                tail = newNode;

            current.Next = newNode;
        }

        public Node<T>? GetHead() => head;
        public Node<T>? GetTail() => tail;
    }
}
