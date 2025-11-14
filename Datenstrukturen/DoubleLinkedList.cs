using System;
using Common;

namespace Datenstrukturen
{
    public class DoubleLinkedList<T>
    {
        private Node<T>? head;
        private Node<T>? tail;

        public Node<T>? GetHead() => head;
        public Node<T>? GetTail() => tail;

        public bool IsEmpty() => head == null;

        // Insert at end
        public void InsertAtEnd(T data)
        {
            var newNode = new Node<T>(data);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
        }

        // Search by predicate
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

        // Insert BEFORE a specific element (using comparer)
        public void InsertBefore(T target, T newData, Func<T, T, bool> comparer)
        {
            var current = head;
            var newNode = new Node<T>(newData);

            while (current != null)
            {
                if (comparer(current.data, target))
                {
                    newNode.Next = current;
                    newNode.Prev = current.Prev;

                    if (current.Prev != null)
                        current.Prev.Next = newNode;
                    else
                        head = newNode;

                    current.Prev = newNode;
                    return;
                }

                current = current.Next;
            }
        }

        // Insert AFTER a specific element (using comparer)
        public void InsertAfter(T target, T newData, Func<T, T, bool> comparer)
        {
            var current = head;
            var newNode = new Node<T>(newData);

            while (current != null)
            {
                if (comparer(current.data, target))
                {
                    newNode.Prev = current;
                    newNode.Next = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = newNode;
                    else
                        tail = newNode;

                    current.Next = newNode;
                    return;
                }

                current = current.Next;
            }
        }
    }
}
