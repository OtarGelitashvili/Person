using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Application.Commands.User.Create;
using Person.Application.Commands.User.Queries;
using Person.Application.Commands.User.Update;
using Person.Application.Responses;

namespace Person.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserResponse>> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UpdateUserCommand command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll([FromQuery] UserQueryFilter command)
        {

            var result = await _mediator.Send(command);
            return Ok(result);

        }
    }
}
