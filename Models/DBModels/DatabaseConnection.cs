using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Courses_app.Models.DBModels
{
    public class DatabaseConnection
    {
        public void DBConnect() {
            MongoClient client = new MongoClient("mongodb://HorseTipsRW:G3n3rat3dP4s5write@ds135039.mlab.com:35039/todompreston");
            IMongoDatabase database = client.GetDatabase("todompreston");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("TestingClientDB");
        }

        public static List<string> DBRead() {
            List<string> fullList = new List<string>();
            var coll = new CourseInfo();

            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("CourseList");

            var result = collec.Find(_ => true).ToList();
            foreach (var item in result)
            {
                var x = item.ToString();
                fullList.Add(x);
            }
            return fullList;
        }

        public static void DBWriteContactForm(BsonDocument docu) {
            // writes data to the collection

            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("ContactForm");

            collec.InsertOne(docu);

        }

        public void DBUserlookup() {
            // controls user login
        }
    }
}
