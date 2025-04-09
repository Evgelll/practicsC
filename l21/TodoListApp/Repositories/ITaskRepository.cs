using TodoListApp.Models;

public interface ITaskRepository
{
    void SaveTasks(List<TaskViewModel> tasks);
    List<TaskViewModel> LoadTasks();
}