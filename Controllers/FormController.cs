using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Courses_app.Models.DBModels ;
using Courses_app.Models;
using MongoDB.Bson;
using MongoDB.Driver;             

namespace Courses_app.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpForm model)
        {

            return Content($"Hello {model.StudentName}");
        }

        [HttpGet]
        public IActionResult AddYourCourse()
        {
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddYourCourse(SuggestCourse model)
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

            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("CourseList");

            collec.InsertOne(docu);
            ViewData["contact"] = model.CourseName;
            return Content($"{model.CourseName} Added");
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

            ViewData["contact"] = model.Email;
            return View();
        }
    }
}
