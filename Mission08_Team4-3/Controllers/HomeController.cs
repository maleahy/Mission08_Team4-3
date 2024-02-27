using Microsoft.AspNetCore.Mvc;
using Mission08_Team4_3.Models;
using System.Diagnostics;

namespace Mission08_Team4_3.Controllers
{
    public class HomeController : Controller
    {
        // Render the Index View
        public IActionResult Index()
        {
            return View();
        }
        // Render the Create View
        public IActionResult Create()
        {
            return View();
        }
        // Render the Quadrants View
        public IActionResult Quadrants()
        {
            return View();
        }
    }
}
