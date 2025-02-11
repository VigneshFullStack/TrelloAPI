namespace TrelloAPI.DTO
{
    public class CardMovementRuleDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("workspace_id")]
        public int WorkspaceId { get; set; }

        [JsonProperty("from_board_id")]
        public int FromBoardId { get; set; }

        [JsonProperty("to_board_id")]
        public int ToBoardId { get; set; }

        [JsonProperty("Board_From")]
        public string? BoardFrom { get; set; } 

        [JsonProperty("Board_To")]
        public string? BoardTo { get; set; } 

        [JsonProperty("from_label_id")]
        public int FromLabelId { get; set; }

        [JsonProperty("Label_from")]
        public string? LabelFrom { get; set; } 

        [JsonProperty("to_label_id")]
        public int ToLabelId { get; set; }

        [JsonProperty("Label_To")]
        public string? LabelTo { get; set; } 

        [JsonProperty("rules")]
        public string? Rules { get; set; }

        [JsonProperty("is_allowed")]
        public bool IsAllowed { get; set; }

        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("updated_date")]
        public DateTime? UpdatedDate { get; set; }

        [JsonProperty("created_by")]
        public string CreatedBy { get; set; }

        [JsonProperty("updated_by")]
        public string? UpdatedBy { get; set; }
    }
}