namespace TrelloAPI.Models;

public class TicketAssignee
{
    [Key]
    public long Id { get; set; }
    public int TicketId { get; set; }
    public Guid? AssignedTo { get; set; }
    public DateTime? AssignedDate { get; set; }
    public bool IsActive { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string UpdatedBy { get; set; }
}