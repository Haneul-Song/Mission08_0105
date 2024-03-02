using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_0105.Models;
using System.Diagnostics;

namespace Mission08_0105.Controllers
{
    public class HomeController : Controller
    {
        private ITodoRepository _repo;
        public HomeController(ITodoRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Todo());
        }
        [HttpPost]
        public IActionResult Create(Todo t)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTodo(t);
                return View("Confirmation");
            }
            else
            {
                return View(new Todo());
            }
        }

        public IActionResult Quadrants()
        {
            var tasks = _repo.GetIncompleteTodosWithCategory() ?? new List<Todo>(); 

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.GetTodoById(id);
            if (recordToEdit == null)
            {
                return NotFound();
            }

            return View("Create", recordToEdit);

        }

        [HttpPost]
        public IActionResult Edit(Todo updatedTask)
        {
            _repo.UpdateTodo(updatedTask); 
            return RedirectToAction("quadrants");
        }

        [HttpPost]
        public IActionResult CompletionStatus(int taskId)
        {
            _repo.ToggleCompletionStatus(taskId);


            return RedirectToAction("Quadrants");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.GetTodoById(id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Todo updatedTask)
        {
            _repo.RemoveTodo(updatedTask); 
            return RedirectToAction("Quadrants");
        }
    }
}
