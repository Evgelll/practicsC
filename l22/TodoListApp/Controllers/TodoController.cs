using Microsoft.AspNetCore.Mvc;
using TodoListApp.Data;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoDbContext _context;

        public TodoController(TodoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string filter = "all")
        {
            var tasks = filter switch
            {
                "active" => _context.TodoItems.Where(t => !t.IsCompleted).ToList(),
                "completed" => _context.TodoItems.Where(t => t.IsCompleted).ToList(),
                _ => _context.TodoItems.ToList()
            };
            ViewBag.Filter = filter;
            return View("Index", tasks); // Явно укажите "Index"
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new TodoItem());
        }

        [HttpPost]
        public IActionResult Create(TodoItem task)
        {
            if (ModelState.IsValid)
            {
                _context.TodoItems.Add(task);
                _context.SaveChanges();
                TempData["Message"] = "Задача добавлена!";
                return RedirectToAction("Index");
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            var task = _context.TodoItems.Find(id);
            if (task != null)
            {
                task.IsCompleted = true;
                _context.SaveChanges();
                TempData["Message"] = "Задача завершена!";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _context.TodoItems.Find(id);
            if (task != null)
            {
                _context.TodoItems.Remove(task);
                _context.SaveChanges();
                TempData["Message"] = "Задача удалена!";
            }
            return RedirectToAction("Index");
        }
    }
}