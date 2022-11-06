namespace TicketService.Lib.Models
{
    public class Event
    {
        public string Name { get; set; } = default!;
        public string? Desc { get; set; }
        public DateTime Date { get; set; }
    }
}
