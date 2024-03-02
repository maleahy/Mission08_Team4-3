using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team4_3.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Mission08_Team4_3.Controllers
{
    public class HomeController : Controller
    {
        private ITodoRepository _repo;
        private ILogger<HomeController> _logger;
        public HomeController(ITodoRepository temp, ILogger<HomeController> logger)
        {
            _repo = temp;
            _logger = logger;
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


            _logger.LogInformation("Submitting Todo: {@Todo}", t);
            if (ModelState.IsValid)
            {
                _repo.AddTodo(t);
                return View("Confirmation", t);
            }

            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogWarning("Model validation error: {ErrorMessage}", error.ErrorMessage);
                }
                return View(t);
            }

        }

        //Quadrants 
        public IActionResult Quadrants()
        {
            var tasks = _repo.GetIncompleteTodosWithCategory() ?? new List<Todo>(); // Ensure it's never null

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
            _repo.UpdateTodo(updatedTask); //Good
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
            _repo.RemoveTodo(updatedTask); //Good
            return RedirectToAction("Quadrants");
        }
    }
}
