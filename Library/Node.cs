namespace Library
{
    public class Node<T>
    {
        public T info;
        public Node<T> next;
        public Node<T> prev;

        public Node(T t)
        {
            info = t;
            next = null;
            prev = null;
        }
    }
}