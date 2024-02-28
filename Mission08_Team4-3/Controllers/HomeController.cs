using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission08_Team4_3.Models;
using System.Diagnostics;

namespace Mission08_Team4_3.Controllers
{
    public class HomeController : Controller

    {
        private CreateTasksContext _context;
        public HomeController(CreateTasksContext temp)
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
            // Create a viewbag to create a dropdown option ***Need to set up Program.cs to make this working -Su***
            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Category)
            .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTasks response)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response);
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

        // Render the Quadrants View
        public IActionResult Quadrants()
        {
            return View();
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
        public IActionResult CreateTasks(CreateTasks response)
        {
            _context.Tasks.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);

        }

        public IActionResult table()
        {
            var tasks = _context.Tasks.Include("Category").ToList(); // Fetch tasks from database

            return View(tasks); // Pass the list of tasks to the view
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View("CreateTasks", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(CreateTasks updatedTask)
        {
            _context.Update(updatedTask);
            _context.SaveChanges();
            return RedirectToAction("quadrants");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasks
                .Single(x => x.TaskId == id);
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(CreateTasks updatedTask)
        {
            _context.Remove(updatedTask);
            _context.SaveChanges();
            return RedirectToAction("quadrants");
        }
    }
}
