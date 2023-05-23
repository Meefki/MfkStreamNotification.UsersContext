using EventBus.Extentions;
using Users.Application.Commands;
using Users.Application.Queries;
using UserDto = Users.Application.Queries.UserDto;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;
        private readonly IUserQueries _userQueries;

        public UsersController(
            IMediator mediator,
            ILogger<UsersController> logger,
            IUserQueries userQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userQueries = userQueries ?? throw new ArgumentNullException(nameof(userQueries));
        }

        [HttpGet]
        [Route("{userId:Guid}")]
        [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetuserAsync(Guid userId)
        {
            try
            {
                // TODO: create handler for query
                // var user = _mediator.Send(new GetUserByIdQuery(userId));
                var user = await _userQueries.GetUserAsync(userId);
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserCommand command)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.Login),
                command.Login,
                command);

            Guid? result = await _mediator.Send(command);

            if (result != null)
                return Ok(result);

            return BadRequest();
        }

        [HttpPut]
        [Route("activate")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ActivateUser([FromBody] ActivateUserCommand command)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.UserId),
                command.UserId,
                command);

            var result = await _mediator.Send(command);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserCommand command)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.UserId),
                command.UserId,
                command);

            var result = await _mediator.Send(command);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("restore")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RestoreUser([FromBody] RestoreUserCommand command)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                command.GetGenericTypeName(),
                nameof(command.UserId),
                command.UserId,
                command);

            var result = await _mediator.Send(command);

            if (result)
                return Ok();

            return BadRequest();
        }
    }
}
