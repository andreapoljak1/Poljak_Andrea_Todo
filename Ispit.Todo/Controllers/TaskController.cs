using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Todo.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // GET: Task/Create
        public ActionResult Create()
        {
           
            ViewBag.TodolistId = _context.Todolist.ToList();
            return View();

        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskTodo taskTodo)
        {
            try
            {
                _context.Task.Add(taskTodo);
                _context.SaveChanges();
                return RedirectToAction("Index", "Todolist");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeStatusTask(int id)
        {
            try
            {
                var taskEdit= _context.Task.FirstOrDefault(s=>s.Id==id);
                taskEdit.Status = true;
                taskEdit.EndDate=DateTime.Now;
                _context.SaveChanges();

                return RedirectToAction("Index", "Todolist");
            }
            catch
            {
                return View();
            }
        }
    }
}
