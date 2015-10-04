using System.Collections.Generic;
using System.Linq;

namespace Edge
{
    public static class AlgoritmPrima
    {
        public static IEnumerable<Edge<T>> GetOstovGraph<T>(IEnumerable<Edge<T>> list, int countNodes, T firstNode)
        {
            var edges = list.ToList();

            var checkList = new List<T> { firstNode };

            var ostov = new List<Edge<T>>();

            while (checkList.Count < countNodes)
            {
                Edge<T> minEdge = null;
                foreach (var edge in edges.Where(edge =>
                    checkList.Contains(edge.FirstNode) && !checkList.Contains(edge.SecondNode) ||
                    !checkList.Contains(edge.FirstNode) && checkList.Contains(edge.SecondNode)))
                {
                    if (minEdge == null)
                    {
                        minEdge = edge;
                        continue;
                    }

                    if (edge.Weight < minEdge.Weight)
                    {
                        minEdge = edge;
                    }
                }

                ostov.Add(minEdge);
                edges.Remove(minEdge);

                checkList.Add(checkList.Contains(minEdge.FirstNode) ? minEdge.SecondNode : minEdge.FirstNode);
            }
            return ostov;
        }
    }
}