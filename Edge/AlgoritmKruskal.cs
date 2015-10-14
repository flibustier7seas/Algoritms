using System.Collections.Generic;
using System.Linq;

namespace Edge
{
    static class AlgoritmKruskal
    {
        static public IEnumerable<Edge<T>> GetOstovGraph<T>(IEnumerable<Edge<T>> list, IEnumerable<T> nodes, int countNodes)
        {
            var ostovList = new List<Edge<T>>();
            var nodeList = nodes.ToList();
            var treesId = new Dictionary<T, int>();
            var dsu = new Dsu(nodeList.Count);

            var i = 0;

            foreach (var node in nodeList)
            {
                treesId[node] = i++;
            }

            var listSort = list.OrderBy(x => x.Weight).ToArray();
            foreach (var edge in listSort)
            {
                var firstTreeId = treesId[edge.FirstNode];
                var secondTreeId = treesId[edge.SecondNode];

                if (dsu.Find(firstTreeId) != dsu.Find(secondTreeId))
                {
                    ostovList.Add(edge);
                    dsu.Unite(firstTreeId, secondTreeId);
                    treesId[edge.FirstNode] = dsu.Find(firstTreeId);
                    treesId[edge.SecondNode] = dsu.Find(secondTreeId);
                }
            }
            return ostovList;
        }
    }
}