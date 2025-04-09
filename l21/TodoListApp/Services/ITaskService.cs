using System.Collections.Generic;
using TodoListApp.Models;

public interface ITaskService
{
    void AddTask(TaskViewModel task);
    void CompleteTask(int id);
    List<TaskViewModel> GetTasks();
}