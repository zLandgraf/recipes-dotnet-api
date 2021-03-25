using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Recipes.Domain;
using Recipes.Infra;

namespace Recipes.Application.Recipes.Commands
{
    public class CreateRecipe : IRequest<Recipe>
    {
        [Required]
        public string Name { get; set; }
        public IEnumerable<IngredientModel> Ingredients { get; set; }
        public class IngredientModel 
        {
            [Required]
            public string Name { get; set; }
            
            [Required]
            public string Unit { get; set; }

            [Required]
            public decimal Amount {get; set;}
        }
    }

    public class CreateRecipeHandler : IRequestHandler<CreateRecipe, Recipe>
    {
        private readonly RecipesContext _context;
        
        public CreateRecipeHandler(RecipesContext context)
        {
            _context = context;
        }

        public async Task<Recipe> Handle(CreateRecipe request, CancellationToken cancellationToken)
        {
            var recipe = new Recipe 
            {
                Name = request.Name,
            };

            var ingredients = request.Ingredients.ToList().Select(model => new Ingredient 
            {
                Name  = model.Name,
                Amount = model.Amount,
                Unit = model.Unit,
            });

            recipe.Ingredients.AddRange(ingredients);
            await _context.Recipe.InsertOneAsync(recipe);
            return recipe;
        }
    }
}