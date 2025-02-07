namespace TrelloAPI.Models;

public class TicketAttachment
{
    [Key]
    public int AttachmentId { get; set; }
    public int TicketId { get; set; }
    public string FilePath { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
}