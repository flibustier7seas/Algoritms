namespace Algoritms
{
    public class Edge<T>
    {
        public Edge(T firstNode, T secondNode, int weight)
        {
            Weight = weight;
            FirstNode = firstNode;
            SecondNode = secondNode;
        }

        public int Weight { private set; get; }
        public T FirstNode{ private set; get; }
        public T SecondNode { private set; get; }
    }
}