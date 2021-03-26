using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Recipes.Commands;
using Recipes.Application.Recipes.Queries;
using Recipes.Domain;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class RecipeController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public RecipeController(IMediator mediatr)
            => _mediatr = mediatr;

        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetRecipes([FromQuery] GetAllRecipes query)
            => await _mediatr.Send(query);

        [HttpPost]
        public async Task<Recipe> AddRecipe([FromBody] CreateRecipe command)
            => await _mediatr.Send(command);
    }
}