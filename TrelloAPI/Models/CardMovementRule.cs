namespace TrelloAPI.Models;

public class CardMovementRule
{
    [Key]
    public int Id { get; set; }
    public int WorkspaceId { get; set; }
    public int FromBoardId { get; set; }
    public int? FromLabelId { get; set; }
    public int ToBoardId { get; set; }
    public int? ToLabelId { get; set; }
    public string Rules { get; set; }
    public bool IsAllowed { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
}