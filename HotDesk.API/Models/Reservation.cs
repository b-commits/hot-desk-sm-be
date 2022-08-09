using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HotDesk.API.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private int Id { get; set; }

        private string Name { get; set; }

        private DateTime startDate { get; set; }

        private DateTime endDate { get; set; }

        private int deskId { get; set; }
    }
}

