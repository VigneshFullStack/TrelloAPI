namespace TrelloAPI.Models;

public class UserDepartment
{
    [Key]
    public int UserDeptId { get; set; }
    public Guid RegId { get; set; }
    public int DeptId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
}