using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MealController
    {
        private readonly IMediator _mediatr;

        public MealController(IMediator mediatr)
            => _mediatr = mediatr;
    }
}
