using MediatR;
using Microsoft.EntityFrameworkCore;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Units
{
    public class UpdateUnit : IRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }

    public class UpdateUnitHandler : AsyncRequestHandler<UpdateUnit>
    {
        protected readonly RecipesContext _context;

        public UpdateUnitHandler(RecipesContext context)
        {
            _context = context;
        }

        protected override async Task Handle(UpdateUnit request, CancellationToken cancellationToken)
        {
            var unit = await _context.Unit.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if(!(unit == null))
            {
                unit.Name = request.Name;

                _context.Unit.Update(unit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
