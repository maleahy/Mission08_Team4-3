using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team4_3.Models;
using System.Diagnostics;

namespace Mission08_Team4_3.Controllers
{
    public class HomeController : Controller

    {
        private TodosContext _context;
        public HomeController(TodosContext temp)
        {
            _context = temp;
        }
        // Render the Index View
        public IActionResult Index()
        {
            return View();
        }
        // Render the Create View
        [HttpGet]
        public IActionResult Create()
        {
            // Create a viewbag to create a dropdown option
            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Category)
            .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Todos response)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Add(response);
                _context.SaveChanges();

                // Render the Confirmation View
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.CategoryTable = _context.Categories
                    .OrderBy(x => x.Category)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult Confirmation()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateTasks()

        {
            ViewBag.Categories = _context.Categories.ToList();
            return View("CreateTasks");
        }


        [HttpPost]
        public IActionResult CreateTasks(Todos response)
        {
            _context.Todos.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);

        }

        //Render quadrants view
        public IActionResult quadrants()
        {
            var tasks = _context.Todos.Include("Category").ToList(); // Fetch tasks from database

            return View(tasks); // Pass the list of tasks to the view
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Todos
                .Single(x => x.TaskId == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View("CreateTasks", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Todos updatedTask)
        {
            _context.Update(updatedTask);
            _context.SaveChanges();
            return RedirectToAction("quadrants");
        }

        [HttpPost]
        public IActionResult CompletionStatus(int taskId)
        {
            var task = _context.Todos.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null)
            {
                task.Completed = !task.Completed; // Toggle the completion status
                _context.SaveChanges();
                return RedirectToAction("Quadrants");
            }
            return NotFound();

        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Todos
                .Single(x => x.TaskId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Todos updatedTask)
        {
            _context.Remove(updatedTask);
            _context.SaveChanges();
            return RedirectToAction("quadrants");
        }
    }
}
