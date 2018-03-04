using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Courses_app.Models;
using MongoDB.Bson;
using MongoDB.Driver;             
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
            BsonDocument docu = new BsonDocument{
                    {"EmailAddress", model.Email},
                    {"Query", model.Query},
                    {"HeardAbout", model.HearAbout}
                };

            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("ContactForm");

            collec.InsertOne(docu);
            ViewData["contact"] = model.Email;
            return View();
        }
    }
}
