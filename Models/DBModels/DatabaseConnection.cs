using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Courses_app.Models.DBModels
{
    // This controls all interaction with the Database through reads and writes. This will not be submitted to Github
    public class DatabaseConnection
    {
        public static List<BsonDocument> DBRead() {
            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("CourseList");

            var result = collec.Find(_ => true).ToList();
            return result;
        }

        public static void DBWriteContactForm(BsonDocument docu) {
            // writes data to the collection

            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("ContactForm");

            collec.InsertOne(docu);

        }
        public static void DBWriteNewCourse(BsonDocument docu) {
            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("CourseList");

            collec.InsertOne(docu);
        }

        public static void DBUserSignUp(BsonDocument docu)
        {
            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("SignUp");

            collec.InsertOne(docu);
        }

        public static void DBCourseSuggestion(BsonDocument docu)
        {
            MongoClient client = new MongoClient("mongodb://CoursesRW:dbpass@ds255768.mlab.com:55768/coursecentral");
            IMongoDatabase database = client.GetDatabase("coursecentral");
            IMongoCollection<BsonDocument> collec = database.GetCollection<BsonDocument>("SuggestedCourses");

            collec.InsertOne(docu);
        }

        public void DBUserlookup() {
            // controls user login
        }
    }
}
