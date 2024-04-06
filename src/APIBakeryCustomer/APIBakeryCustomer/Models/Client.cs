using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace APIBakeryCustomer.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;

        [BsonElement("Address")]
        public string Address { get; set; } = null!;

        [BsonElement("Phone")]
        public string Phone { get; set; } = null!;
    }
}
