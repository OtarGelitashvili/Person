using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Application.Commands;

namespace Person.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CallBoredApiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CallBoredApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> CallApi()
        {
            var result = await _mediator.Send(new CallBoredApiCommad());
            return Ok(result);

        }
    }
}
