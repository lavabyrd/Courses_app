using System;
using Microsoft.AspNetCore.Mvc;
using Courses_app.Models.DBModels ;
using Courses_app.Models;
using MongoDB.Bson;           

namespace Courses_app.Controllers
{
    // This controller looks after Any pages that contain a form or follow on from a form (Thanks pages)

    public class FormController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            ViewBag.somet = DatabaseConnection.DBRead();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ThanksSignUp(SignUpForm model)
        {
            string date = DateTime.Now.ToUniversalTime().ToString();
            BsonDocument docu = new BsonDocument{
                {"StudentName", model.StudentName},
                {"Course_selected", model.Course},
                {"Date Entered", date},
                {"PhoneNumber", model.Phone},
                {"Email", model.Email}
            };
            DatabaseConnection.DBUserSignUp(docu);
            ViewData["contact"] = "Thanks for signing up for " + model.Course;
                return View();
        }

        [HttpGet]
        public IActionResult AddYourCourse()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddYourCourse(AddCourse model)
        {
            string date = DateTime.Now.ToUniversalTime().ToString();
            BsonDocument docu = new BsonDocument{
                {"CourseTitle", model.CourseName},
                {"Coursecode", model.CourseCode},
                {"Price", model.Price},
                {"Dates", model.DateStarting},
                {"CourseLevel", model.Difficulty},
                {"courseSize", model.Size},
                {"CourseDescription", model.Description},
                {"DateAdded", date},
            };
            DatabaseConnection.DBWriteNewCourse(docu);
            return RedirectToAction("Home", "CourseList");
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Thanks(ContactForm model)
        {
            
            string date = DateTime.Now.ToUniversalTime().ToString();
            BsonDocument docu = new BsonDocument{
                    {"EmailAddress", model.Email},
                    {"Query", model.Query},
                    {"HeardAbout", model.HearAbout},
                    {"QueryDate", date}

                };
            DatabaseConnection.DBWriteContactForm(docu);

            ViewData["contact"] = "Thanks! We'll get in touch shortly through " + model.Email;
            return View();
        }

        [HttpGet]
        public IActionResult SuggestACourse()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ThanksCourse(SuggestForm model)
        {
            string date = DateTime.Now.ToUniversalTime().ToString();
            BsonDocument docu = new BsonDocument{
                {"Name", model.Name},
                {"Suggestion", model.Suggestion},
                {"WhySuggestion", model.WhySuggestion},
                {"Email", model.Email},
                {"DateSuggested", date}
            };
            DatabaseConnection.DBCourseSuggestion(docu);
            ViewData["contact"] = "Thanks! We'll get in touch shortly through " + model.Email;
            return View();
        }

    }
}
