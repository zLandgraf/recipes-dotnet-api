using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using Recipes.Application.Common.Extensions;
using Recipes.Domain;
using Recipes.Infra;

namespace Recipes.Application.Recipes.Queries
{
    public class GetAllRecipes : IRequest<IEnumerable<Recipe>>
    {
        public int PageNumber { get; set; } = 1;

        [Range(0, 100)]
        public int ItemsPerPage { get; set; } = 15;
    }

    public class GetAllRecipesHandler : IRequestHandler<GetAllRecipes, IEnumerable<Recipe>>
    {
        private readonly RecipesContext _context;
        private readonly IMapper _mapper;

        public GetAllRecipesHandler(RecipesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Recipe>> Handle(GetAllRecipes request, CancellationToken cancellationToken)
        {
            return await _context.Recipe
               .Find(x => true)
               .ToPaginatedListAsync(request.PageNumber, request.ItemsPerPage);
        }
    }
}