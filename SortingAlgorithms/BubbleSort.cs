using System;
using Common;

namespace SortingAlgorithms
{
    public class BubbleSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(Node<T> head)
        {
            if (head == null || head.Next == null) return;

            bool swapped;
            do
            {
                swapped = false;
                var current = head;
                while (current.Next != null)
                {
                    if (current.data.CompareTo(current.Next.data) > 0)
                    {
                        (current.data, current.Next.data) = (current.Next.data, current.data);
                        swapped = true;
                    }
                    current = current.Next;
                }
            } while (swapped);
        }
    }
}