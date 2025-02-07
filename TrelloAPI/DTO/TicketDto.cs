namespace TrelloAPI.DTO;

public class TicketDto
{
    [JsonProperty("ticket_id")]
    public int? TicketId { get; set; }

    [JsonProperty("ticket_name")]
    public string? TicketName { get; set; }

    [JsonProperty("desc")]
    public string? Desc { get; set; }

    [JsonProperty("order_date")]
    public DateTime? OrderDate { get; set; }

    [JsonProperty("is_data_dependancy")]
    public bool? IsDataDependancy { get; set; }

    [JsonProperty("is_data_dependancy_required")]
    public bool? IsDataDependancyRequired { get; set; }
}