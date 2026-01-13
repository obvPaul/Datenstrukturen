using System;
using Common;

namespace Datenstrukturen
{
    public class MyStack<T> where T : IComparable<T>  // ← Umbenannt!
    {
        private Node<T>? top;
        private ISortAlgorithm<T> sortAlgorithm;

        public MyStack()
        {
            sortAlgorithm = null!;
        }

        public void Push(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var newNode = new Node<T>(data);
            newNode.Next = top;
            if (top != null)
            {
                top.Prev = newNode;
            }
            top = newNode;
        }

        public T? Pop()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");

            T data = top!.data;
            top = top.Next;
            if (top != null)
            {
                top.Prev = null;
            }
            return data;
        }

        public T? Peek()
        {
            if (IsEmpty()) throw new InvalidOperationException("Stack is empty");
            return top!.data;
        }

        public bool IsEmpty() => top == null;

        public Node<T>? GetTop() => top;

        public void SetSortAlgorithm(ISortAlgorithm<T> algorithm)
        {
            sortAlgorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
        }

        public void Sort()
        {
            if (sortAlgorithm == null)
                throw new InvalidOperationException("Sort algorithm not set.");
            if (top == null || top.Next == null) return;

            sortAlgorithm.Sort(top);
        }
    }
}