using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalog.API.Entities
{
    public class ProductChoice
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? ProductId { get; set; }
        public double PriceIncrease { get; set; } = 0;
        public  Choice Choice { get; set; } = null!;
    }
}
