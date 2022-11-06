using MassTransit;
using Microsoft.AspNetCore.Mvc;
using TicketService.Lib.Models;

namespace TicketService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly IPublishEndpoint _publisher;
        private readonly ILogger<TicketController> _logger;

        public TicketController(IPublishEndpoint publisher, ILogger<TicketController> logger)
        {
            _publisher = publisher;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Ticket ticket)
        {
            await _publisher.Publish(ticket);
            _logger.LogInformation($"Queued {nameof(Ticket)}");

            return Ok();
        }
    }
}
