using System;
using System.Collections.Generic;

public class MyDictionary<TKey, TValue>
{
    private List<KeyValuePair<TKey, TValue>>[] _buckets;
    private int _count;

    public MyDictionary(int size = 16)
    {
        _buckets = new List<KeyValuePair<TKey, TValue>>[size];
        for (int i = 0; i < size; i++)
        {
            _buckets[i] = new List<KeyValuePair<TKey, TValue>>();
        }
        _count = 0;
    }

    private int GetBucketIndex(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % _buckets.Length;
    }

    public void Add(TKey key, TValue value)
    {
        var bucket = _buckets[GetBucketIndex(key)];
        foreach (var pair in bucket)
        {
            if (EqualityComparer<TKey>.Default.Equals(pair.Key, key))
            {
                bucket.Remove(pair);
                _count--;
                break;
            }
        }
        bucket.Add(new KeyValuePair<TKey, TValue>(key, value));
        _count++; 
    }

    public bool Remove(TKey key)
    {
        var bucket = _buckets[GetBucketIndex(key)];
        for (int i = 0; i < bucket.Count; i++)
        {
            if (EqualityComparer<TKey>.Default.Equals(bucket[i].Key, key))
            {
                bucket.RemoveAt(i);
                _count--; 
                return true;
            }
        }
        return false;
    }

    public TValue Find(TKey key)
    {
        var bucket = _buckets[GetBucketIndex(key)];
        foreach (var pair in bucket)
        {
            if (EqualityComparer<TKey>.Default.Equals(pair.Key, key))
            {
                return pair.Value;
            }
        }
        return default; 
    }

    public int Count => _count; 

    public IEnumerable<KeyValuePair<TKey, TValue>> GetAll()
    {
        foreach (var bucket in _buckets)
        {
            foreach (var pair in bucket)
            {
                yield return pair; 
            }
        }
    }
}