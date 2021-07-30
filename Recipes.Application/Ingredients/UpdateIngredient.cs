using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Ingredients
{
    public class UpdateIngredient : IRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class UpdateIngredientHandler : AsyncRequestHandler<UpdateIngredient>
    {
        protected readonly RecipesContext _context;

        public UpdateIngredientHandler(RecipesContext context)
        {
            _context = context;
        }

        protected override async Task Handle(UpdateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = await _context.Ingredient.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (!(ingredient == null))
            {
                ingredient.Name = request.Name;

                _context.Ingredient.Update(ingredient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
