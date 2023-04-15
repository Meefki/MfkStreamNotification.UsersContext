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
            var result = await _mediator.Send(command);

            if (result)
                return Ok(result);

            return BadRequest();
        }
    }
}
