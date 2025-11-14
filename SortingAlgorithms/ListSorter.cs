using Common;

namespace SortingAlgorithms
{
    public class ListSorter<T> where T : IComparable<T>
    {
        private ISortAlgorithm<T> _algorithm;

        public ListSorter(ISortAlgorithm<T> algorithm)
        {
            _algorithm = algorithm ?? throw new ArgumentNullException(nameof(algorithm));
        }

        public void SetAlgorithm(ISortAlgorithm<T> algorithm)
        {
            _algorithm = algorithm;
        }

        public void Sort(Node<T> head)
        {
            _algorithm.Sort(head);
        }
    }
}