namespace TrelloAPI.Utility;

public static class DbContextExtensions
{
    public static async Task<List<T>> ExecuteStoredProcedureAsync<T> (
        this DbContext context,
        ILogger logger,
        string storedProcedure,
        params SqlParameter[] parameters
    )
    {
        try
        {
            // Generate parameter placeholders
            var paramPlaceholders = string.Join(", ", parameters.Select(p => "@" + p.ParameterName.TrimStart('@')));

            // Execute stored procedure
            var query = await context.Database.SqlQueryRaw<string>(
                $"EXEC {storedProcedure} {paramPlaceholders}",
                parameters
            ).ToListAsync();

            // Deserialize JSON result
            if (query.Count > 0 && !string.IsNullOrWhiteSpace(query[0]))
            {
                return JsonConvert.DeserializeObject<List<T>>(query[0]) ?? new List<T>();
            }

            return new List<T>();
        }
        catch (JsonReaderException jsonEx)
        {
            logger.LogError(jsonEx, "JSON Deserialization error for {StoredProcedure}: {Error}", storedProcedure, jsonEx.Message);
            throw;  
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error executing stored procedure: {StoredProcedure} with parameters: {Parameters}",
                storedProcedure, parameters);
            return new List<T>();
        }
    }

    public static async Task<int> ExecuteStoredProcedureNonQueryAsync (
        this DbContext context,
        ILogger logger,
        string storedProcedure,
        params SqlParameter[] parameters
    )
    {
        try
        {
            // Generate parameter placeholders
            var paramPlaceholders = string.Join(", ", parameters.Select(p => "@" + p.ParameterName.TrimStart('@')));

            // Execute stored procedure
            return await context.Database.ExecuteSqlRawAsync(
                $"EXEC {storedProcedure} {paramPlaceholders}",
                parameters
            );
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error executing stored procedure: {StoredProcedure} with parameters: {Parameters}",
                storedProcedure, parameters);
            return -1; 
        }
    }
}