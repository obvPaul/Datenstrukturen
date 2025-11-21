// SortingAlgorithms/InsertionSort.cs
using Common;

namespace SortingAlgorithms
{
    public class InsertionSort<T> : ISortAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(Node<T> head)
        {
            if (head == null || head.Next == null) return;

            Node<T>? current = head.Next;

            while (current != null)
            {
                T key = current.data;
                Node<T>? prev = current.Prev;
                Node<T>? walker = current.Prev;

                // Finde die richtige Position im sortierten Teil
                while (walker != null && walker.data.CompareTo(key) > 0)
                {
                    // Verschiebe Daten nach rechts
                    walker.Next.data = walker.data;
                    walker = walker.Prev;
                }

                // key an die gefundene Stelle einfügen
                if (walker == null)
                {
                    head.data = key;  // key wird neuer Head
                }
                else
                {
                    walker.Next.data = key;
                }

                current = current.Next;
            }
        }
    }
}