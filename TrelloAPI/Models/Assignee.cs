namespace TrelloAPI.Models;

public class Assignee
{
    [Key]
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string JobTitle { get; set; }
    public string Photo { get; set; }
    public string DisplayName { get; set; }
    public string GivenName { get; set; }
    public string MobilePhone { get; set; }
    public string Location { get; set; }
    public string Surname { get; set; }
    public Guid? TenantId { get; set; }
    public Guid? OrgId { get; set; }
    public bool IsRegistered { get; set; }
    public bool IsHidden { get; set; }
    public bool IsMailSent { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Guid? UpdatedBy { get; set; }
    public int? DeptId { get; set; }
    public string EmployeeId { get; set; }
    public string PhotoUrl { get; set; }
    public string UserType { get; set; }
}