namespace TrelloAPI.Repositories.Board;

/// <summary>
/// Interface for repository handling operations related to board.
/// </summary>
public interface IBoardRepository
{
    /// <summary>
    /// Retrieves all board entries from the database for a specific workspace.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace to filter boards.</param>
    /// <returns>
    /// A list of <see cref="Models.Board"/> objects representing all the boards in the specified workspace.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    Task<IEnumerable<Models.Board>?> GetBoardsByWorkspaceIdAsync ( int workspaceId );

    /// <summary>
    /// Retrieves board statuses based on workspace ID and board ID.
    /// </summary>
    /// <param name="workspaceId">The ID of the workspace.</param>
    /// <param name="boardId">The ID of the board.</param>
    /// <returns>
    /// A list of <see cref="BoardStatusDto"/> representing the statuses for the specified board and workspace.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    Task<IEnumerable<BoardStatusDto>?> GetBoardStatusesAsync(int workspaceId, int boardId);

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
    Task<bool> InsertOrUpdateCardMovementRulesAsync ( int workspaceId, string userId, string jsonInput );


    /// <summary>
    /// Inserts or updates a ticket tracker entry in the database using the stored procedure 
    /// </summary>
    /// <param name="ticketId">The unique identifier of the ticket.</param>
    /// <param name="boardId">The ID of the board associated with the ticket.</param>
    /// <param name="labelId">The ID of the label assigned to the ticket.</param>
    /// <param name="movedBy">The unique identifier of the user who moved the ticket.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> InsertOrUpdateTicketTrackerAsync ( int ticketId, int boardId, int labelId, Guid movedBy );

    ILogger GetLogger ();
}