using Users.API.Commands;

namespace Users.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserCommand command)
        {
            Guid? result = await _mediator.Send(command);

            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPut]
        [Route("twitch-user")]
        public async Task<IActionResult> LinkTwitchUser([FromBody] LinkTwitchUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpDelete]
        [Route("twitch-user")]
        public async Task<IActionResult> UnlinkTwitchUser([FromBody] UnlinkTwitchUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
