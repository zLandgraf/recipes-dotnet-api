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
        public string Unit { get; set; } 
        public decimal Amount { get; set; }
    }
}
