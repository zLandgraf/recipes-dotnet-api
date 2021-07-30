using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Application.Common;
using Recipes.Application.Common.Extensions;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Units
{
    public class GetUnits : IRequest<PaginatedList<Domain.Unit>>
    {
        public int Offset { get; set; } = 0;

        [Range(0, 100)]
        public int Limit { get; set; } = 3;
    }

    public class GetUnitsHandler : IRequestHandler<GetUnits, PaginatedList<Domain.Unit>>
    {
        protected readonly RecipesContext _context;

        public GetUnitsHandler(RecipesContext context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Domain.Unit>> Handle(GetUnits request, CancellationToken cancellationToken)
        {
            return await _context.Unit
                .AsNoTracking()
                .OrderByDescending(unit => unit.Id)
                .ToPaginatedListAsync(request.Offset, request.Limit);
        }
    }
}
