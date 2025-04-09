using System.IO;
using System.Text.Json;
using TodoListApp.Models;

public class FileTaskRepository : ITaskRepository
{
    private const string FilePath = "tasks.json";

    public void SaveTasks(List<TaskViewModel> tasks)
    {
        var json = JsonSerializer.Serialize(tasks);
        File.WriteAllText(FilePath, json);
    }

    public List<TaskViewModel> LoadTasks()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TaskViewModel>();
        }

        var json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TaskViewModel>>(json) ?? new List<TaskViewModel>();
    }
}