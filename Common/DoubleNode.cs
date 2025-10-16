namespace Common
{
    public class DoubleNode<T>
    {
        public T Data;
        public DoubleNode<T>? Next;
        public DoubleNode<T>? Prev;

        public DoubleNode(T data)
        {
            Data = data;
        }
    }
}
