namespace TicketService.Lib.Models
{
    public class Ticket
    {
        public string UserName { get; set; } = default!;
        public DateTime BookedOn { get; set; } = DateTime.Now;
        public virtual Event Event { get; set; } = default!;
    }
}
