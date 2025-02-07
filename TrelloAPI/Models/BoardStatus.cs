namespace TrelloAPI.Models;

public class BoardStatus
{
    [Key]
    public int LabelId { get; set; }
    public int BoardId { get; set; }
    public int? DisplayId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsFreeze { get; set; } = true;
    public int WorkspaceId { get; set; }
}