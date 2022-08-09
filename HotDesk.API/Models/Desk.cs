using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotDesk.API.Models
{
    public class Desk
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string LocationId { get; set; }
    }
}
