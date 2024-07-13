using System.Collections.Generic;

namespace JDMallen.CodingExercises.LeetCode;

public class Node
{
    public int Key { get; set; }
    public int Value { get; set; }
    public Node Previous { get; set; }
    public Node Next { get; set; }
}

public class LRUCache
{
    private readonly Dictionary<int, Node> _cache = new();
    private Node _lru = null;
    private Node _mru = null;
    private readonly int _capacity;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out var node))
        {
            return -1;
        }

        if (_mru.Key == _lru.Key)
        {
            // there's only one node, so no need to reinsert at end
            return node.Value;
        }

        Remove(node);
        Insert(node);

        return node.Value;
    }

    public void Put(int key, int value)
    {
        if (_cache.TryGetValue(key, out Node existingNode))
        {
            Remove(existingNode);
        }

        var node = new Node { Key = key, Value = value };
        if (_cache.Count >= _capacity && !_cache.ContainsKey(key))
        {
            // evict
            var oldLru = _lru;
            Remove(oldLru);
        }

        Insert(node);
    }

    private void Remove(Node node)
    {
        // if capacity is 1 or node is orphan, next and prev are always null,
        // so update MRU, LRU, and cache
        if (_capacity == 1 || node.Previous == null && node.Next == null)
        {
            _cache.Remove(node.Key);
            _lru = _mru = null;
            return;
        }

        // connect prev and next

        if (node.Previous == null)
        {
            // node is the LRU, so make a new LRU
            _lru = node.Next;
            _lru.Previous = null;
            node.Next = null; // node is now orphaned
            _cache.Remove(node.Key);

            return;
        }


        if (node.Next == null)
        {
            // node is the MRU, so make a new MRU
            _mru = node.Previous;
            node.Previous = null; // node is now orphaned
            _cache.Remove(node.Key);

            return;
        }

        node.Previous.Next = node.Next;
        node.Next.Previous = node.Previous;
        node.Previous = null;
        node.Next = null;

        _cache.Remove(node.Key);
    }

    private void Insert(Node node)
    {
        _cache[node.Key] = node;

        if (_mru == null) // first put
        {
            _mru = node;
        }
        else
        {
            _mru.Next = node;
            node.Previous = _mru;
            _mru = node;
        }

        _lru ??= node; // first put
    }
}
