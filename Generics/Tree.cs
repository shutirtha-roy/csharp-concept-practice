namespace Generics
{
    public class Tree<T> where T : class
    {
        private T[] nodes = new T[100];
        private int index;

        public void AddNode(T node)
        {
            nodes[index++] = node;
        }

        public T DeleteNode(T node)
        {
            int currentIndex = nodes.ToList().FindIndex(item => item.Equals(node));
            T currentItem = nodes[currentIndex];
            nodes[currentIndex] = default(T);

            return currentItem;
        }
    }
}