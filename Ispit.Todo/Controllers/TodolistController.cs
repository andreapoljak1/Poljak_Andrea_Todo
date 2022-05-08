using Ispit.Todo.Data;
using Ispit.Todo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ispit.Todo.Controllers
{
    public class TodolistController : Controller
    {
        private readonly ApplicationDbContext _context;
 
        public TodolistController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Todolist
        public ActionResult Index(int? todoId)
        {

            List<Todolist> tasks = (todoId != null) ?

               _context.Todolist.Where(p => _context.Task.Where(pc => pc.TodolistId == todoId).Select(
                           pc => pc.TodolistId
                       ).ToList().Contains(
                           p.ID
                       )
               ).ToList() :
               _context.Todolist.ToList();
            ViewBag.Task = _context.Task.ToList();
            if (todoId != null)
            {
                ViewBag.Task = _context.Task.Where(s => s.TodolistId == todoId).ToList();
            }
           
            ViewBag.Todolists = _context.Todolist.ToList();



            return View(tasks);
        }

        // GET: Todolist/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Todolist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todolist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Todolist todolist)
        {
            try
            {
                _context.Todolist.Add(todolist);
                _context.SaveChanges();
                var taskIsEmpty = _context.Task.Count();
                if (taskIsEmpty == 0)
                {
                    return RedirectToAction("Create", "Task", _context.Task.ToList());
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Todolist/Edit/5
        public ActionResult Edit(int id)
        {
            var todolist = _context.Todolist.FirstOrDefault(s => s.ID == id);

            if (todolist == null)
            {
                return RedirectToAction("Index");
            }

            return View(todolist);
        }

        // POST: Todolist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Todolist todolist)
        {
            try
            {
                _context.Todolist.Update(todolist);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       
    }
}
