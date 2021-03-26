using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Ingredients.Commands;
using Recipes.Application.Ingredients.Queries;
using Recipes.Application.Ingredients.TransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class IngredientController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public IngredientController(IMediator mediatr)
            => _mediatr = mediatr;
        
        [HttpGet]
        public async Task<IEnumerable<IngredientDTO>> GetIngredient([FromQuery] GetAllIngredients query)
            => await _mediatr.Send(query);
       
        [HttpPost]
        public async Task<IngredientDTO> AddIngredient([FromBody] CreateIngredient command)
            => await _mediatr.Send(command);
    }
}
