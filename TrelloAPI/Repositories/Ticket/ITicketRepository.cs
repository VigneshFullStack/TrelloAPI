namespace TrelloAPI.Repositories.Ticket;

public interface ITicketRepository
{
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
    Task<List<BoardLabelDto>?> GetIndividualBoardTicketsAsync ( int pageIndex, int pageSize, int workspaceId, int boardId );

    /// <summary>
    /// Retrieves all card movement rules from the database.
    /// </summary>
    /// <returns>
    /// A list of <see cref="Models.CardMovementRule"/> objects representing all the rules in the database.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    Task<IEnumerable<Models.CardMovementRule>?> GetAllCardMovementRulesAsync ();

    /// <summary>
    /// Retrieves card movement rules for a specific workspace and board.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to filter card movement rules.</param>
    /// <param name="boardId">The ID of the board to retrieve card movement rules from.</param>
    /// <returns>
    /// A list of <see cref="CardMovementRuleDto"/> containing card movement rules.
    /// Returns an empty list if an error occurs.
    /// </returns>
    Task<List<CardMovementRuleDto>?> GetCardMovementRulesAsync ( int workspaceId, int boardId );

    ILogger GetLogger ();
}