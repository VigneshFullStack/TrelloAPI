namespace TrelloAPI.Utility;

/// <summary>
/// Provides helper methods for executing operations with error handling and logging.
/// </summary>
public static class RepositoryHelper
{
    /// <summary>
    /// Executes an operation with error handling and logging.
    /// </summary>
    /// <typeparam name="TContext">The type of the DbContext.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="contextFactory">The DbContext factory to create a new context instance.</param>
    /// <param name="logger">The logger to log errors.</param>
    /// <param name="operation">The operation to execute.</param>
    /// <param name="errorMessage">Custom error message for logging.</param>
    /// <returns>The result of the operation.</returns>
    public static async Task<TResult> ExecuteWithLoggingAsync<TContext, TResult> (
        IDbContextFactory<TContext> contextFactory,
        ILogger logger,
        Func<TContext, Task<TResult>> operation,
        string errorMessage )
        where TContext : DbContext
    {
        using var context = await contextFactory.CreateDbContextAsync();
        try
        {
            return await operation(context);
        }
        catch (Exception ex)
        {
            LogError(logger, ex, errorMessage);
            throw;
        }
    }

    /// <summary>
    /// Executes an asynchronous action and logs any exceptions that occur.
    /// </summary>
    /// <typeparam name="T">The type of the result returned by the asynchronous action.</typeparam>
    /// <param name="action">The asynchronous action to be executed.</param>
    /// <param name="errorMessage">The error message to be logged in case an exception is thrown.</param>
    /// <param name="logger">The logger used to log the exception.</param>
    /// <returns>A task that represents the asynchronous operation, with the result of type <typeparamref name="T"/>.</returns>
    /// <exception cref="Exception">Throws the caught exception after logging it.</exception>
    /// <remarks>
    /// This method is used to wrap any asynchronous operation that needs exception handling and logging.
    /// If the action fails, the exception is logged with the provided error message and then rethrown.
    /// </remarks>
    public static async Task<T> ExecuteRepositoryWithLoggingAsync<T> ( Func<Task<T>> action, string errorMessage, ILogger logger )
    {
        try
        {
            return await action();
        }
        catch (Exception ex)
        {
            LogError(logger, ex, errorMessage);
            throw;
        }
    }

    /// <summary>
    /// Executes an operation with error handling and logging.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="operation">The operation to execute.</param>
    /// <param name="errorMessage">Custom error message for logging.</param>
    /// <param name="logger">The logger to log errors.</param>
    /// <returns>The result of the operation.</returns>
    public static async Task<TResult> ExecuteWithLoggingAndReturnResultAsync<TResult> (
        Func<Task<TResult>> operation,
        string errorMessage,
        ILogger logger )
    {
        try
        {
            return await operation();
        }
        catch (Exception ex)
        {
            LogError(logger, ex, errorMessage);
            throw;
        }
    }

    /// <summary>
    /// Retrieves the name of the calling method.
    /// </summary>
    /// <typeparam name="String">The type of the returned result, which is a string.</typeparam>
    /// <param name="methodName">Automatically populated with the name of the calling method.</param>
    /// <returns>The name of the calling method as a string.</returns>
    public static string GetMethodName ( [CallerMemberName] string methodName = "" )
    {
        return methodName;
    }

    /// <summary>
    /// Logs an error with a custom message.
    /// </summary>
    /// <param name="logger">The logger to log the error.</param>
    /// <param name="ex">The exception to log.</param>
    /// <param name="message">The custom error message.</param>
    public static void LogError ( ILogger logger, Exception ex, string message )
    {
        logger.LogError(ex, message);
    }
}