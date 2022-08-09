using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotDesk.API.Models
{
    public class Location
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string City { get; set; }
    }
}
