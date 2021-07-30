using MediatR;
using Recipes.Domain;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Units
{
    public class CreateUnit : IRequest
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateUnitHandler : AsyncRequestHandler<CreateUnit>
    {
        protected readonly RecipesContext _context;

        public CreateUnitHandler(RecipesContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateUnit request, CancellationToken cancellationToken)
        {
            var unit = new Domain.Unit { Name = request.Name };

            await _context.Unit.AddAsync(unit);
            await _context.SaveChangesAsync();
        }
    }
}
