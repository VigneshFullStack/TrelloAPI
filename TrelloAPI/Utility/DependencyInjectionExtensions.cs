namespace TrelloAPI.Utility;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddResolversFromAssembly ( this IServiceCollection services, Assembly assembly )
    {
        var resolverTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && (t.Name.EndsWith("QueryResolver") || t.Name.EndsWith("MutationResolver")))
            .ToList();

        foreach (var resolverType in resolverTypes)
        {
            services.AddScoped(resolverType);
        }

        return services;
    }
}