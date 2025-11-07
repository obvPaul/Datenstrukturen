using Common;
using System;

namespace Common
{
    public class Node<T>
    {
        public T data;
        public Node<T> Next;
        public Node<T>? Prev;
        public Node(T argData)
        {
            data = argData;
        }
    }
}