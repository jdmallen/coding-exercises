using System;
using System.Collections.Generic;

namespace JDMallen.CodingExercises.LeetCode
{
    public class LRUCacheDateTime
    {
        private readonly Dictionary<int, Tuple<int, DateTime>> _map;
        private readonly int _capacity;

        public LRUCacheDateTime(int capacity)
        {
            _map = new Dictionary<int, Tuple<int, DateTime>>();
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_map.TryGetValue(key, out var val))
            {
                return -1;
            }

            var returnVal = val.Item1;

            _map[key] = Tuple.Create(val.Item1, DateTime.Now);

            return returnVal;
        }

        public void Put(int key, int val)
        {
            if (_map.Count == _capacity)
            {
                var oldestKey = new KeyValuePair<int, Tuple<int, DateTime>>(
                    -1,
                    Tuple.Create(-1, DateTime.MaxValue));
                foreach (var kvp in _map)
                {
                    if (kvp.Value.Item2 < oldestKey.Value.Item2)
                    {
                        oldestKey = kvp;
                    }
                }

                _map.Remove(oldestKey.Key);
            }

            _map[key] = Tuple.Create(val, DateTime.Now);
        }
    }
}
