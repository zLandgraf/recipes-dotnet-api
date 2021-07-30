using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
