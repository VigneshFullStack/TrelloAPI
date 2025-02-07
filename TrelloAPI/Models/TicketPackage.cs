namespace TrelloAPI.Models;

public class TicketPackage
{
    [Key]
    public int PackageId { get; set; }
    public string PackageName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
}