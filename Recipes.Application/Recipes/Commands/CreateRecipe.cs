using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Driver;
using Recipes.Domain;
using Recipes.Infra;

namespace Recipes.Application.Recipes.Commands
{
    public class CreateRecipe : IRequest<Recipe>
    {
        [Required]
        public string Name { get; set; }
        public List<IngredientModel> Ingredients { get; set; }
        public class IngredientModel 
        {
            [Required]
            public string Id { get; set; }

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

            foreach (var model in request.Ingredients)
            {
                var ingredient = await _context.Ingredient.Find(x => x.Id == model.Id).FirstOrDefaultAsync();
                
                if(ingredient != null)
                {
                    ingredient.Amount = model.Amount;
                    ingredient.Unit = model.Unit;
                    
                    recipe.Ingredients.Add(ingredient);
                }
            }

            await _context.Recipe.InsertOneAsync(recipe);
            return recipe;
        }
    }
}