using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface ISortAlgorithm<T> where T : IComparable<T>
    {
        void Sort(Node<T> head);
    }
}
