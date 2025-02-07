namespace TrelloAPI.DTO;

[Keyless]
public class BoardLabelDto
{
    [JsonProperty("workspace_id")]
    public int? WorkspaceId { get; set; }

    [JsonProperty("board_id")]
    public int? BoardId { get; set; }

    [JsonProperty("board_name")]
    public string? BoardName { get; set; }

    [JsonProperty("label_id")]
    public int? LabelId { get; set; }

    [JsonProperty("label_name")]
    public string? LabelName { get; set; }

    [JsonProperty("tickets")]
    public List<TicketDto> Tickets { get; set; } = new();
}