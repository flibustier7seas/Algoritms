using Algoritms;
using NUnit.Framework;

namespace AlgoritmTests
{
    [TestFixture]
    public class DsuTest
    {
        [Test]
        public void UnionTest()
        {
            var dsu = new Dsu<int>();
            dsu.Add(1);
            dsu.Add(2);

            dsu.Union(1, 2);

            Assert.That(dsu.Find(1), Is.EqualTo(dsu.Find(2)));
        }
    }
}