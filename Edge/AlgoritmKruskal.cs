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

            var i = 0;

            foreach (var node in nodeList)
            {
                treesId[node] = i++;
            }

            var listSort = list.OrderBy(x => x.Weight).ToArray();
            foreach (var edge in listSort.Where(edge => treesId[edge.FirstNode] != treesId[edge.SecondNode]))
            {
                ostovList.Add(edge);

                var oldTreeId = treesId[edge.FirstNode];
                var newTreeId = treesId[edge.SecondNode];

                foreach (var node in nodeList.Where(node => treesId[node] == oldTreeId))
                {
                    treesId[node] = newTreeId;
                }
            }
            return ostovList;
        }
    }
}