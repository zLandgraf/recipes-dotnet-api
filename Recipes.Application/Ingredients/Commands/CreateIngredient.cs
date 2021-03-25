using MediatR;
using Recipes.Domain;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Ingredients.Commands
{
    public class CreateIngredient : IRequest<Ingredient>
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateIngredientHandler : IRequestHandler<CreateIngredient, Ingredient>
    {
        private readonly RecipesContext _context;
        
        public CreateIngredientHandler(RecipesContext context)
        {
            _context = context;
        }

        public async Task<Ingredient> Handle(CreateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient { Name = request.Name };

            await _context.Ingredient.InsertOneAsync(ingredient);
            return ingredient;
        }
    }
}