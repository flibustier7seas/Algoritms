using System.Collections.Generic;
using System.Linq;
using Algoritms;
using NUnit.Framework;

namespace AlgoritmTests
{
    [TestFixture]
    class AlgoritmKruskalTest
    {
        [Test]
        public void GetOstovGraphTest()
        {
            var list = new List<Edge<int>>
            {
                new Edge<int>(1, 2, 15),
                new Edge<int>(1, 3, 7),
                new Edge<int>(2, 4, 6),
                new Edge<int>(2, 7, 7),
                new Edge<int>(3, 4, 15),
                new Edge<int>(3, 5, 84),
                new Edge<int>(4, 6, 21),
                new Edge<int>(5, 6, 17),
                new Edge<int>(6, 7, 3),
                new Edge<int>(6, 8, 24),
                new Edge<int>(7, 8, 39)
            };

            const int CountNodes = 8;

            var nodes = Enumerable.Range(1, CountNodes);

            var ostovGraph = AlgoritmKruskal.GetOstovGraph(list, nodes);

            Assert.That(ostovGraph, Has.Count.EqualTo(7));
        }
    }
}
