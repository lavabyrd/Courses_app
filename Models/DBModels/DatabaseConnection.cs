using System;
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

        public void DBRead() {
            // reads data from collection to a bson item
        }

        public void DBWrite() {
            // writes data to the collection
        }

        public void DBUserlookup() {
            // controls user login
        }
    }
}
