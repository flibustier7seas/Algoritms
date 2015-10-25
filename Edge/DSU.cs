using System.Collections;
using System.Collections.Generic;

namespace Edge
{
    //http://e-maxx.ru/algo/dsu
    /// <summary>
    /// Система непересекающихся множеств 
    /// </summary>
    public class Dsu<T>
    {
        private readonly Dictionary<T, T> _parent;
        // Ранг дерева >= высоты дерева
        private readonly Dictionary<T, int> _rank;

        public Dsu()
        {
            _parent = new Dictionary<T, T>();
            _rank = new Dictionary<T, int>();
        }

        public void Add(T node)
        {
            _parent.Add(node, node);
            _rank.Add(node, 0);
        }

        public T Find(T value)
        {
            if (_parent[value].Equals(value))
            {
                return value;
            }

            var topParent = SearchTopParent(value);

            ChangeTreeParent(value, topParent);

            return topParent;
        }

        public void Union(T first, T second)
        {
            first = Find(first);
            second = Find(second);

            if (first.Equals(second)) return;

            if (_rank[first] < _rank[second])
                _parent[first] = second;
            else
            {
                _parent[second] = first;
                if (_rank[first] == _rank[second])
                    ++_rank[first];
            }
        }

        private T SearchTopParent(T startIndex)
        {
            var topParent = _parent[startIndex];

            while (!_parent[topParent].Equals(topParent))
            {
                topParent = _parent[topParent];
            }

            return topParent;
        }

        private void ChangeTreeParent(T index, T maxParent)
        {
            while (!_parent[index].Equals(maxParent))
            {
                var nextIndex = _parent[index];
                _parent[index] = maxParent;
                index = nextIndex;
            }
        }
    }
}