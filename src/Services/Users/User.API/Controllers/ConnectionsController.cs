using EventBus.Extentions;
using Users.Application.Commands;

namespace Users.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ConnectionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ConnectionsController> _logger;

        public ConnectionsController(
            IMediator mediator,
            ILogger<ConnectionsController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> AddConnection([FromBody] AddConnectionCommand command)
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
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RemoveConnection([FromBody] RemoveConnectionCommand command)
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
