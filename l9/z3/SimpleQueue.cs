using System;
using System.Collections.Generic;

public class SimpleQueue<T> : IQueue<T>
{
    private Queue<T> _queue = new Queue<T>();

    public void Enqueue(T item)
    {
        _queue.Enqueue(item);
    }

    public T Dequeue()
    {
        return _queue.Dequeue();
    }

    public T Peek()
    {
        return _queue.Peek();
    }

    public int Count => _queue.Count;

    public T[] ToArray()
    {
        return _queue.ToArray();
    }
}