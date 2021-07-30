using MediatR;
using Microsoft.AspNetCore.Mvc;
using Recipes.Application.Units;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<ActionResult<dynamic>> GetAll([FromQuery] GetUnits query)
        {
            return await _mediatr.Send(query);
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Create([FromBody] CreateUnit command)
        {
            return await _mediatr.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<dynamic>> Update([FromQuery] int id, [FromBody] UpdateUnit command)
        {
            if (id != command.Id)
                return BadRequest();

            return await _mediatr.Send(command);
        }
    }
}
