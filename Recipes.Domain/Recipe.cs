using System.Collections.Generic;
using MongoDB.Bson;

namespace Recipes.Domain
{
    public class Recipe
    {
        public ObjectId ObjectId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}