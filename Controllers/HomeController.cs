﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Courses_app.Models;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Courses_app.Models.DBModels;

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
            return View();
        }

        public IActionResult CourseList()
        {
            ViewData["Message"] = "Course Listings";

            //ViewBag.markp = DatabaseConnection.DBRead();
            //ViewData.Keys.ElementAt(0);

            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("CourseList");

            var result = collec.Find(_ => true).ToList();
            ViewBag.somet = result;
            return View();
        }

        public IActionResult List()
        {
            
            ViewData["Message"] = "This is the list page";

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
