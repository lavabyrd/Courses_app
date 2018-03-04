using System;
using Courses_app.Models;
using Microsoft.AspNetCore.Mvc;



namespace Courses_app.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddCourse(AddCourseFormModel model)
        {
            
            return Content($"Hello {model.CourseName}");
        }


        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Thanks(ContactForm model)
        {

            ViewData["contact"] = model.Email;
            return View();
        }
    }
}
