namespace TrelloAPI.Models;

public class TicketTracker
{
    [Key]
    public int Id { get; set; }
    public int? TicketId { get; set; }
    public int? BoardId { get; set; }
    public int? LabelId { get; set; }
    public Guid? MovedBy { get; set; }
    public DateTime? MovedDate { get; set; }
}