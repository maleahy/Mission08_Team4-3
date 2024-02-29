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
            ViewBag.Categories = _context.Categories.ToList();
            return View("Create");
        }

        [HttpPost]
        public IActionResult Todos(Todos response)
        {
            _context.Tasks.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);

        }

        public IActionResult Confirmation()
        {
            return View();
        }

        //Render quadrants view
        public IActionResult quadrants()
        {
            var tasks = _context.Tasks
                .Where(t => !t.Completed)
                .Include("Category")
                .ToList(); // Fetch tasks from database

            return View(tasks); // Pass the list of tasks to the view
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View("Create", recordToEdit);
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
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == taskId);
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
            var recordToDelete = _context.Tasks
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
