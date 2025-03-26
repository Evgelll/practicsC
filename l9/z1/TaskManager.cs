using System.Collections;

public class TaskManager
{
    private Queue _taskQueue = new Queue();

    public void AddTask(Task task)
    {
        _taskQueue.Enqueue(task);
    }

    public Task ProcessTask()
    {
        if (_taskQueue.Count > 0)
        {
            return (Task)_taskQueue.Dequeue();
        }
        return null; 
    }

    public Task[] GetPendingTasks()
    {
        Task[] tasks = new Task[_taskQueue.Count];
        _taskQueue.CopyTo(tasks, 0);
        return tasks;
    }
}