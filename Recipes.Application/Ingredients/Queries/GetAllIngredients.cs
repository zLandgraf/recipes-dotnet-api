using MediatR;
using MongoDB.Driver;
using Recipes.Domain;
using Recipes.Infra;
using Recipes.Infra.MongoConfig;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Ingredients.Queries
{
    public class GetAllIngredients : IRequest<IEnumerable<Ingredient>>
    {
    }

    public class GetAllIngredientsHandler : IRequestHandler<GetAllIngredients, IEnumerable<Ingredient>>
    {
        private readonly RecipesContext _context;
        
        public GetAllIngredientsHandler(RecipesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredient>> Handle(GetAllIngredients request, CancellationToken cancellationToken)
        {
            return await _context.Ingredient.Find(ingredient => true).ToListAsync();
        }
    }
}
