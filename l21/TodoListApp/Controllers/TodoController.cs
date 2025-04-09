using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;

public class TodoController : Controller
{
    private readonly ITaskService _taskService;

    public TodoController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index(string filter = "all")
    {
        var tasks = _taskService.GetTasks();
        // Фильтрация задач
        ViewBag.Filter = filter;
        return View(tasks);

        ViewBag.Filter = filter; // Передаем фильтр в представление
        return View(tasks);
    }

    [HttpPost]
    public IActionResult Create(TaskViewModel task)
    {
        if (ModelState.IsValid)
        {
            _taskService.AddTask(task);
            TempData["Message"] = "Задача добавлена!";
            return RedirectToAction("Index");
        }
        return View(task);
    }

    public IActionResult Complete(int id)
    {
        _taskService.CompleteTask(id);
        TempData["Message"] = "Задача завершена!";
        return RedirectToAction("Index");
    }

}