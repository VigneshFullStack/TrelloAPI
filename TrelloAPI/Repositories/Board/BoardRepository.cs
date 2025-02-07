namespace TrelloAPI.Repositories.Board;

/// <summary>
/// Repository class to manage board related operations.
/// </summary>
public class BoardRepository (
        IDbContextFactory<ApplicationDbContext> contextFactory,
        ILogger<BoardRepository> logger
    ) : IBoardRepository
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;
    private readonly ILogger<BoardRepository> _logger = logger;
    private string repositoryName => GetType().Name;

    // Method to get the logger
    public ILogger GetLogger () => _logger;

    /// <summary>
    /// Retrieves all board entries from the database.
    /// </summary>
    /// <returns>
    /// A list of <see cref="Models.Board"/> objects representing all the boards in the database.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    public async Task<IEnumerable<Models.Board>?> GetAllBoardsAsync ()
    {
        return await RepositoryHelper.ExecuteWithLoggingAsync(
            _contextFactory,
            _logger,
            async context =>
            {
                return await context.Boards
                    .AsNoTracking()                       
                    .ToListAsync();
            },
            $"Error retrieving all boards in repository: {repositoryName}, method: {RepositoryHelper.GetMethodName()}"
        );
    }

    /// <summary>
    /// Retrieves board statuses based on workspace ID and board ID.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="boardId">The ID of the board.</param>
    /// <returns>
    /// A list of <see cref="BoardStatusDto"/> representing the statuses for the specified board and workspace.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    public async Task<IEnumerable<BoardStatusDto>?> GetBoardStatusesAsync ( int workspaceId, int boardId )
    {
        return await RepositoryHelper.ExecuteWithLoggingAsync(
            _contextFactory,
            _logger,
            async context =>
            {
                return await context.BoardStatuses
                    .Where(bs => bs.WorkspaceId == workspaceId && bs.BoardId == boardId)
                    .Select(bs => new BoardStatusDto
                    {
                        LabelId = bs.LabelId,
                        StatusName = bs.Name,
                        BoardId = bs.BoardId,
                        WorkspaceId = bs.WorkspaceId,
                        IsActive = bs.IsActive
                    })
                    .AsNoTracking()
                    .ToListAsync();
            },
            $"Error retrieving board statuses for WorkspaceID: {workspaceId}, BoardID: {boardId} in repository: {repositoryName}, method: {RepositoryHelper.GetMethodName()}"
        );
    }

    /// <summary>
    /// Inserts or updates card movement rules in the database using the stored procedure 
    /// </summary>
    /// <param name="workspaceId">The unique identifier of the workspace where the card movement rules apply.</param>
    /// <param name="userId">The ID of the user performing the insert or update operation.</param>
    /// <param name="jsonInput">
    /// A JSON string representing the card movement rules to be inserted or updated. 
    /// The JSON should include properties: from_board_id, to_board_id, from_label_id, and to_label_id.
    /// </param>
    /// <returns>
    /// <c>true</c> if the operation completes successfully; otherwise, <c>false</c>.
    /// </returns>
    public async Task<bool> InsertOrUpdateCardMovementRulesAsync ( int workspaceId, string userId, string jsonInput )
    {
        var methodName = RepositoryHelper.GetMethodName();
        try
        {
            _logger.LogInformation("{Repository}.{Method} - Inserting or updating card movement rules for Workspace ID: {WorkspaceID}", repositoryName, methodName, workspaceId);

            using (var context = _contextFactory.CreateDbContext())
            {
                var result = await context.ExecuteStoredProcedureNonQueryAsync(
                    _logger,
                    "dbo.[sp_InsertOrUpdateCardMovementRules]",
                    new SqlParameter("@workspace_id", workspaceId),
                    new SqlParameter("@user_id", userId),
                    new SqlParameter("@jsonInput", jsonInput)
                );

                return result > 0;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repository}.{Method} - Error inserting or updating card movement rules for Workspace ID: {WorkspaceID}", repositoryName, methodName, workspaceId);
            return false;
        }
    }

    /// <summary>
    /// Inserts or updates a ticket tracker entry in the database using the stored procedure 
    /// </summary>
    /// <param name="ticketId">The unique identifier of the ticket.</param>
    /// <param name="boardId">The ID of the board associated with the ticket.</param>
    /// <param name="labelId">The ID of the label assigned to the ticket.</param>
    /// <param name="movedBy">The unique identifier of the user who moved the ticket.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> InsertOrUpdateTicketTrackerAsync ( int ticketId, int boardId, int labelId, Guid movedBy )
    {
        try
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.ExecuteStoredProcedureNonQueryAsync(
                    _logger,
                    "dbo.[sp_InsertOrUpdateTicketTracker]",
                    new SqlParameter("@ticketId", ticketId),
                    new SqlParameter("@boardId", boardId),
                    new SqlParameter("@labelId", labelId),
                    new SqlParameter("@movedBy", movedBy)
                );
                return true;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error inserting/updating ticket tracker for TicketID: {TicketID}", ticketId);
            return false;
        }
    }
}