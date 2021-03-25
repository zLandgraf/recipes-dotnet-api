using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Recipes.Domain
{
    public class Recipe
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; private set; }
        
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
    }
}