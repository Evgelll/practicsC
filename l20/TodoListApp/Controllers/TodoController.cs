using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> _todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Купить продукты", IsCompleted = false },
            new TodoItem { Id = 2, Title = "Закончить отчет", IsCompleted = true }
        };

        public IActionResult Index(string filter = "all")
        {
            var todos = filter switch
            {
                "completed" => _todos.Where(t => t.IsCompleted).ToList(),
                "active" => _todos.Where(t => !t.IsCompleted).ToList(),
                _ => _todos
            };
            ViewBag.Filter = filter;
            return View(todos);
        }

        [HttpPost]
        public IActionResult Create(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                int newId = _todos.Any() ? _todos.Max(t => t.Id) + 1 : 1;
                _todos.Add(new TodoItem { Id = newId, Title = title, IsCompleted = false });
            }
            return RedirectToAction("Index");
        }

        public IActionResult Complete(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo != null)
            {
                todo.IsCompleted = true;
            }
            return RedirectToAction("Index");
        }
    }
}