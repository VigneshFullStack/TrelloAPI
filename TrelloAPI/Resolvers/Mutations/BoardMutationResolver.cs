namespace TrelloAPI.Resolvers.Mutations;

public class BoardMutationResolver (
        IBoardRepository boardRepository
    )
{
    private readonly IBoardRepository _boardRepository = boardRepository;
    private string mutationName => GetType().Name;

    /// <summary>
    /// Calls the repository method to insert or update card movement rules with logging.
    /// </summary>
    /// <param name="workspaceId">The unique identifier of the workspace where the card movement rules apply.</param>
    /// <param name="userId">The unique identifier of the user performing the operation.</param>
    /// <param name="jsonInput">The JSON-formatted input containing the card movement rules to be inserted or updated.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> InsertOrUpdateCardMovementRulesAsync ( int workspaceId, string userId, string jsonInput )
    {
        return await RepositoryHelper.ExecuteRepositoryWithLoggingAsync(
            () => _boardRepository.InsertOrUpdateCardMovementRulesAsync(workspaceId, userId, jsonInput),
            $"Error inserting or updating card movement rules in resolver: {mutationName}, method: {RepositoryHelper.GetMethodName()}",
            _boardRepository.GetLogger()
        );
    }

    /// <summary>
    /// Calls the repository method to insert or update the ticket tracker entry with logging.
    /// </summary>
    /// <param name="ticketId">The unique identifier of the ticket.</param>
    /// <param name="boardId">The ID of the board associated with the ticket.</param>
    /// <param name="labelId">The ID of the label assigned to the ticket.</param>
    /// <param name="movedBy">The unique identifier of the user who moved the ticket.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> InsertOrUpdateTicketTrackerAsync ( int ticketId, int boardId, int labelId, Guid movedBy )
    {
        return await RepositoryHelper.ExecuteRepositoryWithLoggingAsync(
            () => _boardRepository.InsertOrUpdateTicketTrackerAsync(ticketId, boardId, labelId, movedBy),
            $"Error inserting/updating ticket tracker for TicketID: {ticketId} in resolver: {mutationName}, method: {RepositoryHelper.GetMethodName()}",
            _boardRepository.GetLogger()
        );
    }
}