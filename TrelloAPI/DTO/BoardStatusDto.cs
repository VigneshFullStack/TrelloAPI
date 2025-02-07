namespace TrelloAPI.DTO;

public class BoardStatusDto
{
    public int LabelId { get; set; }
    public string StatusName { get; set; }
    public int BoardId { get; set; }
    public int WorkspaceId { get; set; }
    public bool IsActive { get; set; }
}