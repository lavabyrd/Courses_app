using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
            BsonDocument[] list = result.ToArray();
            Console.WriteLine(list);
            Console.WriteLine("ehhh");
            foreach (var item in result)
            {
                
                var x = item.ToString();
                fullList.Add(x);

            }

            //foreach (var item in fullList)
            //{
            //    item.Split(",");
            //}
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
