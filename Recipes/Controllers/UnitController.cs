using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UnitController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UnitController(IMediator mediatr)
            => _mediatr = mediatr;
    }
}
