public static class GraphQLExtensions
{
    public static IServiceCollection AddGraphQLSchema ( this IServiceCollection services )
    {
        var assembly = Assembly.GetExecutingAssembly();

        // Automatically find all GraphQL Object Types (Queries & Mutations)
        var graphQLTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(ObjectType)))
            .ToList();

        var requestExecutorBuilder = services
            .AddGraphQLServer()
            .DisableIntrospection(false)
            .AddAuthorization()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddInMemorySubscriptions();

        // Register all found GraphQL types dynamically
        foreach (var type in graphQLTypes)
        {
            requestExecutorBuilder.AddType(type);
        }

        return services;
    }
}