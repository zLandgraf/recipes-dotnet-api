using AutoMapper;
using MediatR;
using Recipes.Application.Ingredients.TransferObjects;
using Recipes.Domain;
using Recipes.Infra;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Recipes.Application.Ingredients.Commands
{
    public class CreateIngredient : IRequest<IngredientDTO>
    {
        [Required]
        public string Name { get; set; }
    }

    public class CreateIngredientHandler : IRequestHandler<CreateIngredient, IngredientDTO>
    {
        private readonly RecipesContext _context;
        private readonly IMapper _mapper;

        public CreateIngredientHandler(RecipesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IngredientDTO> Handle(CreateIngredient request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient { Name = request.Name };

            await _context.Ingredient.InsertOneAsync(ingredient);
            
            return _mapper.Map<IngredientDTO>(ingredient);
        }
    }
}