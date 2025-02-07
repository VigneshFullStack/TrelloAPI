namespace TrelloAPI.Repositories.Workspace;

/// <summary>
/// Repository class to manage workspace related operations.
/// </summary>
public class WorkspaceRepository (
        IDbContextFactory<ApplicationDbContext> contextFactory,
        ILogger<WorkspaceRepository> logger
    ) : IWorkspaceRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;
    private readonly ILogger<WorkspaceRepository> _logger = logger;
    private string repositoryName => GetType().Name;

    // Method to get the logger
    public ILogger GetLogger () => _logger;

    /// <summary>
    /// Retrieves all workspace entries from the database.
    /// </summary>
    /// <returns>
    /// A list of <see cref="Models.Workspace"/> objects representing all the workspaces in the database.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    public async Task<IEnumerable<Models.Workspace>?> GetAllWorkspacesAsync ()
    {
        return await RepositoryHelper.ExecuteWithLoggingAsync(
            _contextFactory,
            _logger,
            async context =>
            {
                return await context.Workspaces
                    .AsNoTracking()               
                    .ToListAsync();
            },
            $"Error retrieving all workspaces in repository: {repositoryName}, method: {RepositoryHelper.GetMethodName()}"
        );
    }
}