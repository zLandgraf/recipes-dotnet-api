using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PlanningController
    {
        private readonly IMediator _mediatr;

        public PlanningController(IMediator mediatr)
            => _mediatr = mediatr;
    }
}
