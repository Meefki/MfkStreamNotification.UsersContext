using EventBus.Extentions;
using Users.API.Commands;

namespace Users.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IMediator mediator,
            ILogger<UsersController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
        [Route("twitch-user")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LinkTwitchUser([FromBody] LinkTwitchUserCommand command)
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

        [HttpDelete]
        [Route("twitch-user")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UnlinkTwitchUser([FromBody] UnlinkTwitchUserCommand command)
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
