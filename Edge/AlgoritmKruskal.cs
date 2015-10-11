using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace Edge
{
    static class AlgoritmKruskal
    {
        static public IEnumerable<Edge<T>> GetOstovGraph<T>(IEnumerable<Edge<T>> list, IEnumerable<T> nodes, int countNodes)
        {
            var ostovList = new List<Edge<T>>();

            var trees = new Dictionary<T, int>();
            var i = 0;

            foreach (var node in nodes)
            {
                trees[node] = i++;
            }

            var listSort = list.OrderBy(x => x.Weight);
            foreach (var edge in listSort)
            {
                if (trees[edge.FirstNode] != trees[edge.SecondNode])
                {
                    ostovList.Add(edge);

                    if (trees[edge.FirstNode] > trees[edge.SecondNode])
                    {
                        
                    }
                }
            }
            return ostovList;
        }
    }
}