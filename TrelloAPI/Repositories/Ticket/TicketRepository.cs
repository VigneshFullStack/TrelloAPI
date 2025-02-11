namespace TrelloAPI.Repositories.Ticket;

/// <summary>
/// Repository class to manage ticket related operations.
/// </summary>
public class TicketRepository (
        IDbContextFactory<ApplicationDbContext> contextFactory,
        ILogger<TicketRepository> logger
    ) : ITicketRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;
    private readonly ILogger<TicketRepository> _logger = logger;
    private string repositoryName => GetType().Name;

    // Method to get the logger
    public ILogger GetLogger () => _logger;

    /// <summary>
    /// Retrieves paginated board tickets for a specific workspace and board.
    /// </summary>
    /// <param name="pageIndex">The page number to retrieve (e.g., 1, 2, 3).</param>
    /// <param name="pageSize">The number of records to fetch per page.</param>
    /// <param name="workspaceId">The ID of the workspace to filter tickets.</param>
    /// <param name="boardId">The ID of the board to retrieve tickets from.</param>
    /// <returns>
    /// A list of <see cref="BoardLabelDto"/> containing board labels and their associated tickets.
    /// Returns an empty list if an error occurs.
    /// </returns>
    public async Task<List<BoardLabelDto>?> GetIndividualBoardTicketsAsync ( int pageIndex, int pageSize, int workspaceId, int boardId )
    {
        var methodName = RepositoryHelper.GetMethodName();
        try
        {
            _logger.LogInformation("{Repository}.{Method} - Retrieving board tickets for Workspace ID: {WorkspaceID}, Board ID: {BoardID}",
                repositoryName, methodName, workspaceId, boardId);

            using (var context = _contextFactory.CreateDbContext())
            {
                var result = await context.ExecuteStoredProcedureAsync<BoardLabelDto>(
                    _logger,
                    "dbo.[sp_getindividualboardtickets]",
                    new SqlParameter("@PageIndex", pageIndex),
                    new SqlParameter("@PageSize", pageSize),
                    new SqlParameter("@workspace_id", workspaceId),
                    new SqlParameter("@board_id", boardId)
                );

                return result;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repository}.{Method} - Error retrieving board tickets for Workspace ID: {WorkspaceID}, Board ID: {BoardID}",
                repositoryName, methodName, workspaceId, boardId);
            return new List<BoardLabelDto>();
        }
    }

    /// <summary>
    /// Retrieves all card movement rules from the database.
    /// </summary>
    /// <returns>
    /// A list of <see cref="Models.CardMovementRule"/> objects representing all the rules in the database.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    public async Task<IEnumerable<Models.CardMovementRule>?> GetAllCardMovementRulesAsync ()
    {
        return await RepositoryHelper.ExecuteWithLoggingAsync(
            _contextFactory,
            _logger,
            async context =>
            {
                return await context.CardMovementRules
                    .AsNoTracking()
                    .ToListAsync();
            },
            $"Error retrieving all card movement rules in repository: {repositoryName}, method: {RepositoryHelper.GetMethodName()}"
        );
    }

    /// <summary>
    /// Retrieves card movement rules for a specific workspace and board.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to filter card movement rules.</param>
    /// <param name="boardId">The ID of the board to retrieve card movement rules from.</param>
    /// <returns>
    /// A list of <see cref="CardMovementRuleDto"/> containing card movement rules.
    /// Returns an empty list if an error occurs.
    /// </returns>
    public async Task<List<CardMovementRuleDto>?> GetCardMovementRulesAsync ( int workspaceId, int boardId )
    {
        var methodName = RepositoryHelper.GetMethodName();
        try
        {
            _logger.LogInformation("{Repository}.{Method} - Retrieving card movement rules for Workspace ID: {WorkspaceID}, Board ID: {BoardID}",
                repositoryName, methodName, workspaceId, boardId);

            using (var context = _contextFactory.CreateDbContext())
            {
                var result = await context.ExecuteStoredProcedureAsync<CardMovementRuleDto>(
                    _logger,
                    "dbo.[sp_GetCardMovementRules]",
                    new SqlParameter("@workspace_id", workspaceId),
                    new SqlParameter("@board_id", boardId)
                );

                return result;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repository}.{Method} - Error retrieving card movement rules for Workspace ID: {WorkspaceID}, Board ID: {BoardID}",
                repositoryName, methodName, workspaceId, boardId);
            return new List<CardMovementRuleDto>();
        }
    }
}