namespace TrelloAPI.DTO
{
    public class CardMovementRuleDto
    {
        public int Id { get; set; }
        public int WorkspaceId { get; set; }
        public int FromBoardId { get; set; }
        public int ToBoardId { get; set; }
        public string? BoardFrom { get; set; }
        public string? BoardTo { get; set; }
        public int FromLabelId { get; set; }
        public string? LabelFrom { get; set; }
        public int ToLabelId { get; set; }
        public string? LabelTo { get; set; }
        public string? Rules { get; set; }
        public bool IsAllowed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}