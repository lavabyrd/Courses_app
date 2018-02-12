using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Courses_app.Models;

namespace Courses_app.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page about wha?.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your new contact page.";

            return View();
        }

        public IActionResult List()
        {
            ViewData["Message"] = "This is the list page blahhhhhhh";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
