public class QueueManager<T>
{
    private readonly SimpleQueue<T> _queue = new SimpleQueue<T>();

    public void AddItem(T item)
    {
        _queue.Enqueue(item);
    }

    public T RemoveItem()
    {
        return _queue.Dequeue();
    }

    public T PeekItem()
    {
        return _queue.Peek();
    }

    public void PrintQueue()
    {
        Console.WriteLine("Содержимое очереди:");
        var items = _queue.ToArray();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }
}