namespace TrelloAPI.Models;

public class Status
{
    [Key]
    public int StatusId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
}