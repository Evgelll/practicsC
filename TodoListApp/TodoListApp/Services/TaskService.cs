using TodoListApp.Models;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private List<TaskViewModel> _tasks;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
        _tasks = _taskRepository.LoadTasks(); // Загрузка задач из файла
    }

    public void AddTask(TaskViewModel task)
    {
        int newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
        task.Id = newId;
        _tasks.Add(task);
        _taskRepository.SaveTasks(_tasks); // Сохранение задач
    }

    public void CompleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            _taskRepository.SaveTasks(_tasks); // Сохранение изменений
        }
    }

    public List<TaskViewModel> GetTasks()
    {
        return _tasks;
    }
}