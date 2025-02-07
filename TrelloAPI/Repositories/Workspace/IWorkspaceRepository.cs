namespace TrelloAPI.Repositories.Workspace;

/// <summary>
/// Interface for repository handling operations related to workspace.
/// </summary>
public interface IWorkspaceRepository
{

    /// <summary>
    /// Retrieves all workspace entries from the database.
    /// </summary>
    /// <returns>
    /// A list of <see cref="Models.Workspace"/> objects representing all the workspaces in the database.
    /// Returns <c>null</c> if an error occurs or if no entries are found.
    /// </returns>
    Task<IEnumerable<Models.Workspace>?> GetAllWorkspacesAsync ();

    ILogger GetLogger ();
}