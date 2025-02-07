namespace TrelloAPI.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int BoardId { get; set; }
    public int? OrderId { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? DueDate { get; set; }
    public int? LabelId { get; set; }
    public int? PackageId { get; set; }
    public int? CustomerId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDataDependency { get; set; } = false;
    public bool IsDataDependencyRequired { get; set; } = false;
}