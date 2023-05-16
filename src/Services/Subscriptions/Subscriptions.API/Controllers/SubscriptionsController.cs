using Microsoft.AspNetCore.Mvc;

namespace Subscriptions.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ILogger<SubscriptionsController> _logger;

        public SubscriptionsController(ILogger<SubscriptionsController> logger)
        {
            _logger = logger;
        }
    }
}