using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirBnbApi.Models
{
    public class Contract
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ContractDate")]
        public string ContractDate { get; set; } = null!;

        [BsonElement("Owner")]
        public string Owner { get; set; } = null!;

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("HouseId")]
        public string HouseId { get; set; } = null!;

        public House? House { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("UserId")]
        public string UserId { get; set; } = null!;

        public User? User { get; set; }
    }
}