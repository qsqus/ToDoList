using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoTaskController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ToDoTaskController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var toDoTaskList = _db.ToDoTasks.ToList();

            return View(toDoTaskList);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            if (id is null || id == 0)
            {
                // Create
                return View(new ToDoTask());
            }

            // Edit
            ToDoTask? taskFromDb = _db.ToDoTasks.Find(id);

            if (taskFromDb is null)
            {
                return NotFound();
            }

            return View(taskFromDb);
        }

        [HttpPost]
        public IActionResult CreateOrEdit(ToDoTask obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    // Create
                    _db.ToDoTasks.Add(obj);
                }
                else
                {
                    // Edit
                    _db.ToDoTasks.Update(obj);
                }

                _db.SaveChanges();

                return PartialView("_DisplayTaskList", _db.ToDoTasks.ToList());
            }

            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            ToDoTask? taskFromDb = _db.ToDoTasks.Find(id);

            if (taskFromDb is null)
            {
                return NotFound();
            }

            _db.ToDoTasks.Remove(taskFromDb);
            _db.SaveChanges();
  
            return PartialView("_DisplayTaskList", _db.ToDoTasks.ToList());

        }

        [HttpPost]
        public IActionResult ToggleCompletedState(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            ToDoTask? taskFromDb = _db.ToDoTasks.Find(id);

            if (taskFromDb is null)
            {
                return NotFound();
            }

            taskFromDb.IsCompleted = !taskFromDb.IsCompleted;

            _db.ToDoTasks.Update(taskFromDb);
            _db.SaveChanges();

            return PartialView("_DisplayTaskList", _db.ToDoTasks.ToList());

        }

    }
}