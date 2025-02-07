namespace TrelloAPI.AppDbContext;

public class ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options, IConfiguration configuration ) : DbContext(options)
{
    private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<Board> Boards { get; set; }
    public DbSet<BoardStatus> BoardStatuses { get; set; }
    public DbSet<TicketPackage> TicketPackages { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketAssignee> TicketAssignees { get; set; }
    public DbSet<TicketAttachment> TicketAttachments { get; set; }
    public DbSet<TicketTracker> TicketTrackers { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Assignee> Assignees { get; set; }
    public DbSet<UserDepartment> UserDepartments { get; set; }
    public DbSet<CardMovementRule> CardMovementRules { get; set; }

    protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating ( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity<Assignee>(entity =>
        {
            entity.ToTable("assignee", "dbo");

            entity.HasKey(e => e.UserId);
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.JobTitle).HasColumnName("job_title");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.DisplayName).HasColumnName("display_name");
            entity.Property(e => e.GivenName).HasColumnName("given_name");
            entity.Property(e => e.MobilePhone).HasColumnName("mobile_phone");
            entity.Property(e => e.Location).HasColumnName("location");
            entity.Property(e => e.Surname).HasColumnName("surname");
            entity.Property(e => e.TenantId).HasColumnName("tenant_id");
            entity.Property(e => e.OrgId).HasColumnName("org_id");
            entity.Property(e => e.IsRegistered).HasColumnName("is_registered");
            entity.Property(e => e.IsHidden).HasColumnName("is_hidden");
            entity.Property(e => e.IsMailSent).HasColumnName("is_mail_sent");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.UserType).HasColumnName("user_type");
        });

        modelBuilder.Entity<Workspace>(entity =>
        {
            entity.ToTable("workspace", "dbo");

            entity.HasKey(e => e.WorkspaceId);
            entity.Property(e => e.WorkspaceId).HasColumnName("workspace_id");
            entity.Property(e => e.WorkspaceName).HasColumnName("workspace_name");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<Board>(entity =>
        {
            entity.ToTable("board", "dbo"); 

            entity.HasKey(e => e.BoardId);
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.BoardName).HasColumnName("board_name");
            entity.Property(e => e.WorkspaceId).HasColumnName("workspace_id");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.IsCustom).HasColumnName("is_custom");
            entity.Property(e => e.ForwardOnly).HasColumnName("forward_only");
            entity.Property(e => e.PackageIds).HasColumnName("package_ids");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<BoardStatus>(entity =>
        {
            entity.ToTable("boardstatus", "dbo");
            entity.HasKey(e => e.LabelId);
            entity.Property(e => e.LabelId).HasColumnName("label_id");
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.DisplayId).HasColumnName("display_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsFreeze).HasColumnName("is_freeze");
            entity.Property(e => e.WorkspaceId).HasColumnName("workspace_id");
        });

        modelBuilder.Entity<TicketPackage>(entity =>
        {
            entity.ToTable("ticket_package", "dbo");
            entity.HasKey(e => e.PackageId);
            entity.Property(e => e.PackageId).HasColumnName("package_id");
            entity.Property(e => e.PackageName).HasColumnName("package_name");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.ToTable("ticket", "dbo");
            entity.HasKey(e => e.TicketId);
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.BoardId).HasColumnName("board_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate).HasColumnName("order_date");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.LabelId).HasColumnName("label_id");
            entity.Property(e => e.PackageId).HasColumnName("package_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsDataDependency).HasColumnName("is_data_dependancy");
            entity.Property(e => e.IsDataDependencyRequired).HasColumnName("is_data_dependancy_required");
        });

        modelBuilder.Entity<TicketAssignee>(entity =>
        {
            entity.ToTable("ticket_assignee", "dbo");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");
            entity.Property(e => e.AssignedDate).HasColumnName("assigned_date");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<TicketAttachment>(entity =>
        {
            entity.ToTable("ticket_attachment", "dbo");
            entity.HasKey(e => e.AttachmentId);
            entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.FilePath).HasColumnName("file_path");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<TicketTracker>(entity =>
        {
            entity.ToTable("ticket_tracker", "dbo");
            entity.HasKey(e => e.Id);

            entity.Property(e => e.TicketId).IsRequired();
            entity.Property(e => e.BoardId).IsRequired();
            entity.Property(e => e.LabelId).IsRequired();
            entity.Property(e => e.MovedBy).IsRequired();
            entity.Property(e => e.MovedDate)
                  .HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("status", "dbo");
            entity.HasKey(e => e.StatusId);
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("department", "dbo");
            entity.HasKey(e => e.DeptId);
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.DeptName).HasColumnName("dept_name");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<UserDepartment>(entity =>
        {
            entity.ToTable("user_department", "dbo");
            entity.HasKey(e => e.UserDeptId);
            entity.Property(e => e.UserDeptId).HasColumnName("user_dept_id");
            entity.Property(e => e.RegId).HasColumnName("reg_id");
            entity.Property(e => e.DeptId).HasColumnName("dept_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<CardMovementRule>(entity =>
        {
            entity.ToTable("card_movement_rules", "dbo");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.WorkspaceId).HasColumnName("workspace_id");
            entity.Property(e => e.FromBoardId).HasColumnName("from_board_id");
            entity.Property(e => e.FromLabelId).HasColumnName("from_label_id");
            entity.Property(e => e.ToBoardId).HasColumnName("to_board_id");
            entity.Property(e => e.ToLabelId).HasColumnName("to_label_id");
            entity.Property(e => e.Rules).HasColumnName("rules");
            entity.Property(e => e.IsAllowed).HasColumnName("is_allowed");
            entity.Property(e => e.CreatedDate).HasColumnName("created_date");
            entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });
    }
}