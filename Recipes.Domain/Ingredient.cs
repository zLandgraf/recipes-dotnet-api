using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recipes.Domain
{
    public class Ingredient
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Amount Amount { get; set; }
    }

    public class Amount 
    {
        public string Unit { get; set; } 
        public decimal Value { get; set; }
    }
}
