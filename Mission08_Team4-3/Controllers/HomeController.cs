using Microsoft.AspNetCore.Mvc;
using Mission08_Team4_3.Models;
using System.Diagnostics;

namespace Mission08_Team4_3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Quadrants()
        {
            return View();
        }


    }
}
