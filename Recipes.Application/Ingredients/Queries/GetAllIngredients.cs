using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using MongoDB.Driver;
using Recipes.Application.Common.Extensions;
using Recipes.Application.Ingredients.TransferObjects;
using Recipes.Infra;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Ingredients.Queries
{
    public class GetAllIngredients : IRequest<IEnumerable<IngredientDTO>>
    {
        public int PageNumber { get; set; } = 1;

        [Range(0, 100)]
        public int ItemsPerPage { get; set; } = 10;
    }

    public class GetAllIngredientsHandler : IRequestHandler<GetAllIngredients, IEnumerable<IngredientDTO>>
    {
        private readonly RecipesContext _context;
        private readonly IMapper _mapper;

        public GetAllIngredientsHandler(RecipesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IngredientDTO>> Handle(GetAllIngredients request, CancellationToken cancellationToken)
        {
           var ingredients = await _context.Ingredient
                 .Find(x => true)
                 .ToPaginatedListAsync(request.PageNumber, request.ItemsPerPage);

            return ingredients
                .AsQueryable()
                .ProjectTo<IngredientDTO>(_mapper.ConfigurationProvider);
        }
    }
}
