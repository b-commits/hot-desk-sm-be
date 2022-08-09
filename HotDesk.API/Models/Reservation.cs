using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotDesk.API.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public int deskId { get; set; }
    }
}

