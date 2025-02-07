namespace TrelloAPI.Models;

public class Workspace
{
    [Key]
    public int WorkspaceId { get; set; }
    public string WorkspaceName { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
}