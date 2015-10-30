using System.Collections.Generic;

using Algoritms;

using NUnit.Framework;

namespace AlgoritmTests
{
    [TestFixture]
    class AlgoritmDijkstraTest
    {
        [Test]
        public void GetShortestPathsTest()
        {
            var edgeList = new List<Edge<int>>
                               {
                                   new Edge<int>(0, 1, 5),
                                   new Edge<int>(0, 5, 30),
                                   new Edge<int>(1, 2, 8),
                                   new Edge<int>(1, 3, 4),
                                   new Edge<int>(2, 3, 9),
                                   new Edge<int>(3, 4, 2),
                                   new Edge<int>(4, 5, 7),
                                   new Edge<int>(4, 6, 11),
                                   new Edge<int>(6, 5, 12)
                               };

            var shortestPath = AlgoritmDijkstra.GetShortestPaths(edgeList, 0);

            Assert.That(shortestPath[6], Is.EqualTo(22));
        }
    }
}
