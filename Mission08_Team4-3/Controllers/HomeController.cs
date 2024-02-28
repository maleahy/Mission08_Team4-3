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
        public IActionResult Create()
        {
            // Create a viewbag to create a dropdown option ***Need to set up Program.cs to make this working -Su***
            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.Category)
            .ToList();

            return View();
        }
        // Render the Quadrants View
        public IActionResult Quadrants()
        {
            return View();
        }
    }
}
