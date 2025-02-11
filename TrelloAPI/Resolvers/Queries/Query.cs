namespace TrelloAPI.Resolvers.Query;

public class Query (
        WorkspaceQueryResolver workspaceResolver,
        BoardQueryResolver boardResolver,
        TicketQueryResolver ticketResolver
    )
{
    private readonly WorkspaceQueryResolver _workspaceResolver = workspaceResolver;
    private readonly BoardQueryResolver _boardResolver = boardResolver;
    private readonly TicketQueryResolver _ticketResolver = ticketResolver;

    // Workspaces
    public Task<IEnumerable<Models.Workspace>?> GetAllWorkspacesAsync () =>
        _workspaceResolver.GetAllWorkspacesAsync();

    // Boards
    public Task<IEnumerable<Models.Board>?> GetBoardsByWorkspaceIdAsync ( int workspaceId ) =>
        _boardResolver.GetBoardsByWorkspaceIdAsync(workspaceId);

    // Board Statuses
    public Task<IEnumerable<BoardStatusDto>?> GetBoardStatusesAsync ( int workspaceId, int boardId ) =>
        _boardResolver.GetBoardStatusesAsync(workspaceId, boardId);

    // Tickets
    public Task<List<BoardLabelDto>?> GetIndividualBoardTicketsAsync ( int pageIndex, int pageSize, int workspaceId, int boardId ) =>
        _ticketResolver.GetIndividualBoardTicketsAsync(pageIndex, pageSize, workspaceId, boardId);

    public Task<IEnumerable<Models.CardMovementRule>?> GetAllCardMovementRulesAsync () =>
        _ticketResolver.GetAllCardMovementRulesAsync();

    public Task<List<CardMovementRuleDto>?> GetCardMovementRulesAsync ( int workspaceId, int boardId ) =>
        _ticketResolver.GetCardMovementRulesAsync(workspaceId, boardId);
}