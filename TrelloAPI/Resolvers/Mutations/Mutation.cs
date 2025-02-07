namespace TrelloAPI.Resolvers.Mutations;

public class Mutation (
        BoardMutationResolver ticketMutationResolver
   )
{
    private readonly BoardMutationResolver _ticketMutationResolver = ticketMutationResolver;

    public Task<bool> InsertOrUpdateCardMovementRulesAsync ( int workspaceId, string userId, string jsonInput ) =>
        _ticketMutationResolver.InsertOrUpdateCardMovementRulesAsync(workspaceId, userId, jsonInput);

    public Task<bool> InsertOrUpdateTicketTrackerAsync ( int ticketId, int boardId, int labelId, Guid movedBy ) =>
        _ticketMutationResolver.InsertOrUpdateTicketTrackerAsync(ticketId, boardId, labelId, movedBy);
}