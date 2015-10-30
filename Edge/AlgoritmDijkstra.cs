using System.Collections.Generic;
using System.Linq;

namespace Algoritms
{
    public static class AlgoritmDijkstra
    {
        public static Dictionary<T, int> GetShortestPaths<T>(List<Edge<T>> edgeList, T startNode)
        {
            // Минимальное расстояние до ребра
            var weights = new Dictionary<T, int>();

            // Проверенные узлы
            var nodeCheck = new HashSet<T>();

            // Очередь узлов для обработки
            var queue = new Queue<T>();

            queue.Enqueue(startNode);
            weights.Add(startNode, 0);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                var list = edgeList.Where(x => x.FirstNode.Equals(node) || x.SecondNode.Equals(node));

                foreach (var edge in list)
                {
                    // Соседний узел
                    var neighbor = edge.FirstNode.Equals(node) ? edge.SecondNode : edge.FirstNode;

                    var newWeight = weights[node] + edge.Weight;

                    if (weights.ContainsKey(neighbor))
                    {
                        var neighborWeight = weights[neighbor];

                        if (newWeight < neighborWeight)
                        {
                            weights[neighbor] = newWeight;
                        }
                    }
                    else
                    {
                        weights[neighbor] = newWeight;
                    }

                    if (nodeCheck.Contains(neighbor))
                    {
                        continue;
                    }

                    nodeCheck.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
            return weights;
        }
    }
}
