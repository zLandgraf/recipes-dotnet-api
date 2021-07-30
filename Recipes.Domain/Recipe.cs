using System.Collections.Generic;

namespace Recipes.Domain
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Serving { get; set; }
        public List<RecipeIngredient> Ingredients { get; private set; }
        
        public Recipe()
        {
            Ingredients = new List<RecipeIngredient>();
        }
    }
}