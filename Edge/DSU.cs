namespace Edge
{
    class Dsu
    {
        private readonly int[] _parent;

        // Ранг дерева >= высоты дерева
        private readonly int[] _rank;
        public Dsu(int count)
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

            var topParent = SearchTopParent(value);

            ChangeTreeParent(value, topParent);

            return topParent;
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


        private void ChangeTreeParent(int index, int maxParent)
        {
            while (_parent[index] != maxParent)
            {
                var nextIndex = _parent[index];
                _parent[index] = maxParent;
                index = nextIndex;
            }
        }

        private int SearchTopParent(int startIndex)
        {
            var topParent = _parent[startIndex];

            while (_parent[topParent] != topParent)
            {
                topParent = _parent[topParent];
            }

            return topParent;
        }
    }
}
