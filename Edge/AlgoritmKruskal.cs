using System.Collections.Generic;
using System.Linq;

namespace Edge
{
    public static class AlgoritmKruskal
    {
        static public IEnumerable<Edge<T>> GetOstovGraph<T>(IEnumerable<Edge<T>> list, IEnumerable<T> nodes, int countNodes)
        {
            var ostovList = new List<Edge<T>>();
            var dsu = new Dsu<T>();

            foreach(var node in nodes){
                dsu.Add(node);
            }

            var listSort = list.OrderBy(x => x.Weight).ToArray();

            foreach (var edge in listSort)
            {
                var firstNode = edge.FirstNode;
                var secondNode = edge.SecondNode;

                if (!dsu.Find(firstNode).Equals(dsu.Find(secondNode)))
                {
                    ostovList.Add(edge);
                    dsu.Union(firstNode, secondNode);
                }
            }
            return ostovList;
        }
    }
}