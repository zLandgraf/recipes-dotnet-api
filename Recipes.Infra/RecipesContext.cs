using Microsoft.EntityFrameworkCore;
using Recipes.Domain;

namespace Recipes.Infra
{
    public class RecipesContext : DbContext
    {
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get;  set; }
        public DbSet<Planning> Planning { get; set; }
        public DbSet<RecipePlanning> RecipePlanning { get; set; }
        public DbSet<Meal> Meal { get; set; }
        public DbSet<Unit> Unit { get; set; }

        public RecipesContext(DbContextOptions<RecipesContext> options) : base (options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredient>(recipeIngredient =>
            {
                recipeIngredient.HasKey(x => new { x.RecipeId, x.IngredientId });
            });

            modelBuilder.Entity<RecipePlanning>(recipePlanning =>
            {
                recipePlanning.HasKey(x => new { x.RecipeId, x.PlanningId, x.MealId });
            });
        }
    }
}
