using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotDesk.API.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string DeskId { get; set; }
    }
}
