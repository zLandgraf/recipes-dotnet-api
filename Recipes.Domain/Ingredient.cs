using System.Collections.Generic;

namespace Recipes.Domain
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RecipeIngredient> Recipes { get; set; }
    }
}
