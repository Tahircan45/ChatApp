using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace ChatApp.Model
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Content { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserName { get; set; }
    }
}
