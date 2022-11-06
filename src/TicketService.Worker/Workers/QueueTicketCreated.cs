using MassTransit;
using TicketService.Lib.Models;

namespace TicketService.Worker.Workers
{
    internal class QueueTicketCreated : IConsumer<Ticket>
    {
        readonly ILogger<QueueTicketCreated> _logger;

        public QueueTicketCreated(ILogger<QueueTicketCreated> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Ticket> context)
        {
            _logger.LogInformation("Received ticket to event: {name}", context.Message.Event.Name);
            return Task.CompletedTask;
        }
    }
}
