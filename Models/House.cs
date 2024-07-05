using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirBnbApi.Models
{
    public class HouseAddress
    {
        [BsonElement("city")]
        public string City { get; set; } = null!;

        [BsonElement("state")]
        public string State { get; set; } = null!;

        [BsonElement("country")]
        public string Country { get; set; } = null!;
    }

    public class House
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("HouseName")]
        public string HouseName { get; set; } = null!;

        [BsonElement("HouseType")]
        public string HouseType { get; set; } = null!;

        [BsonElement("HousePrice")]
        public decimal HousePrice { get; set; }

        [BsonElement("HouseAddress")]
        public HouseAddress HouseAddress { get; set; } = null!;
    }
}