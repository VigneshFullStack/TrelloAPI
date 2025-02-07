namespace TrelloAPI.Models;

public class Department
{
    [Key]
    public int DeptId { get; set; }
    public string DeptName { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public Guid? CreatedBy { get; set; }
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    public Guid? UpdatedBy { get; set; }
}