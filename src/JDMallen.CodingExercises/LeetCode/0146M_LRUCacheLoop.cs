using System;
using System.Collections.Generic;
using System.Linq;

namespace JDMallen.CodingExercises.LeetCode
{
    public class LRUCacheLoop
    {
        private Dictionary<int, Tuple<int, int>> _map;
        private readonly int _capacity;
        private int _latestAccessed;

        public LRUCacheLoop(int capacity)
        {
            _map = new Dictionary<int, Tuple<int, int>>();
            _capacity = capacity;
            _latestAccessed = 0;
        }

        public int Get(int key)
        {
            if (!_map.TryGetValue(key, out var val))
            {
                return -1;
            }

            int returnVal = val.Item1;

            if (_latestAccessed == int.MaxValue)
            {
                ResetAccessCounter();
            }

            _map[key] = Tuple.Create(val.Item1, ++_latestAccessed);

            return returnVal;
        }

        public void Put(int key, int val)
        {
            if (_map.ContainsKey(key))
            {
                _map[key] = Tuple.Create(val, ++_latestAccessed);

                return;
            }

            if (_map.Count == _capacity)
            {
                var oldestKey = new KeyValuePair<int, Tuple<int, int>>(
                    -1,
                    Tuple.Create(-1, int.MaxValue));
                foreach (KeyValuePair<int, Tuple<int, int>> kvp in _map.Where(
                    kvp => kvp.Value.Item2 < oldestKey.Value.Item2))
                {
                    oldestKey = kvp;
                }

                _map.Remove(oldestKey.Key);
            }

            if (_latestAccessed == int.MaxValue)
            {
                ResetAccessCounter();
            }

            _map[key] = Tuple.Create(val, ++_latestAccessed);
        }

        private void ResetAccessCounter()
        {
            _map = _map.OrderBy(kvp => kvp.Value.Item2)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            int i;
            for (i = 0; i < _map.Count; i++)
            {
                _map[i] = Tuple.Create(_map[i].Item1, i);
            }

            _latestAccessed = i;
        }
    }
}
