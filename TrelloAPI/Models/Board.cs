namespace TrelloAPI.Models;

public class Board
{
    [Key]
    public int BoardId { get; set; }
    public string BoardName { get; set; }
    public int WorkspaceId { get; set; }
    public bool IsDefault { get; set; }
    public bool IsCustom { get; set; }
    public bool ForwardOnly { get; set; }
    public string PackageIds { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
}