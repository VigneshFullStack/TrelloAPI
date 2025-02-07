using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Load configuration
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .Build();

// Configure DbContext
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(10),
            errorNumbersToAdd: null
        )
    )
);

// Configure Serilog
builder.Host.UseSerilog(( context, configuration ) =>
        configuration.ReadFrom.Configuration(context.Configuration));

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration);
//builder.Services.AddAuthorization();

// Register repositories
builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
builder.Services.AddScoped<IBoardRepository, BoardRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// Auto-register all Query & Mutation resolvers
builder.Services.AddResolversFromAssembly(typeof(Program).Assembly);

// Register GraphQL (Using Extension Method)
builder.Services.AddGraphQLSchema();

builder.Services.AddHttpContextAccessor();

// Configure CORS
var allowedOrigins = builder.Configuration.GetSection("AllowedCorsOrigins").Get<string[]>();
builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy", build =>
            //build.SetIsOriginAllowed(origin => allowedOrigins.Any(ao => origin.EndsWith(ao)))
            build.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseWebSockets();

app.UseRouting();

//app.UseAuthentication();

//app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    var graphQLConfig = builder.Configuration.GetSection("GraphQL");

    endpoints.MapGraphQL("/api/graphql")
    .WithOptions(new GraphQLServerOptions
    {
        EnableSchemaRequests = graphQLConfig.GetValue<bool>("EnableSchemaRequests"),
        Tool =
            {
                Enable = graphQLConfig.GetValue<bool>("Tool:Enable"),
                DisableTelemetry = graphQLConfig.GetValue<bool>("Tool:DisableTelemetry"),
                UseBrowserUrlAsGraphQLEndpoint = graphQLConfig.GetValue<bool>("Tool:UseBrowserUrlAsGraphQLEndpoint")
            }
    });
});

app.MapGraphQLWebSocket();

app.MapGraphQL();

app.Run();