using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Ingredients.Commands;
using Recipes.Application.Ingredients.Queries;
using Recipes.Domain;
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
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IEnumerable<Ingredient>> GetIngredient()
        {
            return await _mediatr.Send(new GetAllIngredients());
        } 

        [HttpPost]
        public async Task<Ingredient> AddIngredient([FromBody] CreateIngredient command)
        {
            return await _mediatr.Send(command);
        }
    }
}
