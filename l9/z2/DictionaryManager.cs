public class DictionaryManager<TKey, TValue>
{
    private MyDictionary<TKey, TValue> _dictionary = new MyDictionary<TKey, TValue>();

    public void AddKeyValue(TKey key, TValue value)
    {
        _dictionary.Add(key, value);
    }

    public bool RemoveKey(TKey key)
    {
        return _dictionary.Remove(key);
    }

    public TValue FindValue(TKey key)
    {
        return _dictionary.Find(key);
    }

    public void DisplayAll()
    {
        foreach (var pair in _dictionary.GetAll())
        {
            Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
        }
    }
}