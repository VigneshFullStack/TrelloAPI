namespace TrelloAPI.Resolvers.Query;

public class WorkspaceQueryResolver (
        IWorkspaceRepository workspaceRepository
    )
{
    private readonly IWorkspaceRepository _workspaceRepository = workspaceRepository;
    private string queryName => GetType().Name;

    // Get all workspaces
    public async Task<IEnumerable<Models.Workspace>?> GetAllWorkspacesAsync ()
    {
        return await RepositoryHelper.ExecuteRepositoryWithLoggingAsync(
            () => _workspaceRepository.GetAllWorkspacesAsync(),
            $"Error retrieving workspaces in resolver: {queryName}, method: {RepositoryHelper.GetMethodName()}",
            _workspaceRepository.GetLogger()
        );
    }
}