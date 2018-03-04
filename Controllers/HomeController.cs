using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Courses_app.Models;
using Courses_app.Models.DBModels;

namespace Courses_app.Controllers
{
    // This controller looks after Index, About, The main Course List, FAQ Tips and Errors
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult CourseList()
        {
            ViewData["Message"] = "Course Listings";
            ViewBag.somet = DatabaseConnection.DBRead();
            return View();
        }

        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult Tips()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
