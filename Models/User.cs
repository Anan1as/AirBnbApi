using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirBnbApi.Models
{
    public class Address
    {
        [BsonElement("city")]
        public string City { get; set; } = null!;

        [BsonElement("state")]
        public string State { get; set; } = null!;

        [BsonElement("country")]
        public string Country { get; set; } = null!;
    }

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; } = null!;

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("email")]
        public string Email { get; set; } = null!;

        [BsonElement("phone")]
        public string Phone { get; set; } = null!;

        [BsonElement("address")]
        public Address Address { get; set; } = null!;
    }
}