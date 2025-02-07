namespace TrelloAPI.Resolvers.Query;

public class TicketQueryResolver (
        ITicketRepository ticketRepository
    )
{
    private readonly ITicketRepository _ticketRepository = ticketRepository;
    private string queryName => GetType().Name;

    // Get tickets based on workspaceId and boardId
    public async Task<List<BoardLabelDto>?> GetIndividualBoardTicketsAsync (int pageIndex , int pageSize, int workspaceId, int boardId)
    {
        return await RepositoryHelper.ExecuteRepositoryWithLoggingAsync(
            () => _ticketRepository.GetIndividualBoardTicketsAsync(pageIndex, pageSize, workspaceId, boardId),
            $"Error retrieving tickets in resolver: {queryName}, method: {RepositoryHelper.GetMethodName()}",
            _ticketRepository.GetLogger()
        );
    }
}