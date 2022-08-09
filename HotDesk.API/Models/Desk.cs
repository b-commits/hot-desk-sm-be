using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotDesk.API.Models
{
    public class Desk
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private int Id { get; set; }

        private int LocationId { get; set; }
      
    }
}

