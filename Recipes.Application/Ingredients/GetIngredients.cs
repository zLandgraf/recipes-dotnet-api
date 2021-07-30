using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Common;
using Recipes.Application.Common.Extensions;
using Recipes.Domain;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Ingredients
{
    public class GetIngredients : IRequest<PaginatedList<Ingredient>>
    {
        public int Offset { get; set; } = 0;

        [Range(0, 100)]
        public int Limit { get; set; } = 3;
    }

    public class GetIngredientsHandler : IRequestHandler<GetIngredients, PaginatedList<Ingredient>>
    {
        protected readonly RecipesContext _context;

        public GetIngredientsHandler(RecipesContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Ingredient>> Handle(GetIngredients request, CancellationToken cancellationToken)
        {
            return await _context.Ingredient
               .AsNoTracking()
               .OrderByDescending(ingredient => ingredient.Id)
               .ToPaginatedListAsync(request.Offset, request.Limit);
        }
    }
}
