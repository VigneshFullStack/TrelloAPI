namespace TrelloAPI.Resolvers.Query;

public class Query (
        WorkspaceQueryResolver workspaceResolver,
        BoardQueryResolver boardResolver
    )
{
    private readonly WorkspaceQueryResolver _workspaceResolver = workspaceResolver;
    private readonly BoardQueryResolver _boardResolver = boardResolver;

    // Workspaces
    public Task<IEnumerable<Models.Workspace>?> GetAllWorkspacesAsync () =>
        _workspaceResolver.GetAllWorkspacesAsync();


    // Boards
    public Task<IEnumerable<Models.Board>?> GetAllBoardsAsync ( ) =>
        _boardResolver.GetAllBoardsAsync();
}