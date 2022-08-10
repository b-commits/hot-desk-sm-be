using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Swashbuckle.AspNetCore.Annotations;

namespace HotDesk.API.Models
{
    public class Reservation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [SwaggerSchema(ReadOnly = true)]
        public string? Id { get; set; }

        [MaxLength(50)]
        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public DateTime StartDate { get; set; }

        [BsonRequired]
        public DateTime EndDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonRequired]
        public string DeskId { get; set; }
    }
}
