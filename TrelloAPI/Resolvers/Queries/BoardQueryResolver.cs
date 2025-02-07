namespace TrelloAPI.Resolvers.Query;

public class BoardQueryResolver (
        IBoardRepository boardRepository
    )
{
    private readonly IBoardRepository _boardRepository = boardRepository;
    private string queryName => GetType().Name;

    // Get all boards
    public async Task<IEnumerable<Models.Board>?> GetAllBoardsAsync ()
    {
        return await RepositoryHelper.ExecuteRepositoryWithLoggingAsync(
            () => _boardRepository.GetAllBoardsAsync(),
            $"Error retrieving boards in resolver: {queryName}, method: {RepositoryHelper.GetMethodName()}",
            _boardRepository.GetLogger()
        );
    }

    // Get board statuses

    public async Task<IEnumerable<BoardStatusDto>?> GetBoardStatusesAsync ( int workspaceId, int boardId )
    {
        return await RepositoryHelper.ExecuteRepositoryWithLoggingAsync(
        () => _boardRepository.GetBoardStatusesAsync(workspaceId, boardId),
            $"Error retrieving boards in resolver: {queryName}, method: {RepositoryHelper.GetMethodName()}",
            _boardRepository.GetLogger()
        );
    }
}