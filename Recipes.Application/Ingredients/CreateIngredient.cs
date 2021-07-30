using MediatR;
using Recipes.Domain;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Ingredients
{
    public class CreateIngredient : IRequest
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateIngredientHandler : AsyncRequestHandler<CreateIngredient>
    {
        protected readonly RecipesContext _context;

        public CreateIngredientHandler(RecipesContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient{ Name = request.Name };

            await _context.Ingredient.AddAsync(ingredient);
            await _context.SaveChangesAsync();
        }
    }
}
