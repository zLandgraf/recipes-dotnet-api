using System;

namespace Recipes.Domain
{
    public class RecipePlanning
    {
        public int PlanningId { get; set; }
        public Planning Planning { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
