using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edge
{
    class DSU
    {
        private readonly int[] _parent;
        private readonly int[] _rank;
        public DSU(int count)
        {
            _rank = new int[count];
            _parent = new int[count];
            for (var i = 0; i < count; i++)
            {
                _parent[i] = i;
                _rank[i] = 0;
            }
        }

        public int Find(int value)
        {
            if (_parent[value] == value)
            {
                return value;
            }
            return _parent[value] = Find(_parent[value]);
        }

        public void Unite(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (_rank[x] < _rank[y])
                _parent[x] = y;
            else
            {
                _parent[y] = x;
                if (_rank[x] == _rank[y])
                    ++_rank[x];
            }
        }
    }
}
