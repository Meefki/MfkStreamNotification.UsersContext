namespace Users.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration config)
    {
        Configuration = config;
    }

    public virtual IServiceProvider ConfigureServices(IServiceCollection services)
    {
        services
            .AddCustomMvc(Configuration)
            .AddSwaggerGen()
            .AddCustomDbContext(Configuration);

        var container = new ContainerBuilder();
        container.Populate(services);

        return new AutofacServiceProvider(container.Build());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        var pathBase = Configuration["PATH_BASE"];
        if (!string.IsNullOrEmpty(pathBase))
        {
            loggerFactory.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
            app.UsePathBase(pathBase);
        }

        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{(!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty)}/swagger/v1/swagger.json", "Users.API V1");
                c.OAuthClientId("usersswaggerui");
                c.OAuthAppName("Users Swagger UI");
            });

        app.UseRouting();
        app.UseCors("DefaultPolicy");
    }
}

static class CustomExtentionsMethods
{
    public static IServiceCollection AddCustomMvc(
        this IServiceCollection services,
        IConfiguration config)
    {
        services
            .AddControllers();

        services
            .AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy",
                    builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins(config["Cors:Origins"] ?? "http://localhost"));
            });

        return services;
    }

    public static IServiceCollection AddCustomDbContext(
        this IServiceCollection services,
        IConfiguration config)
    {
        services.AddDbContext<UsersContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("mssql"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(
                        typeof(Startup)
                            .GetTypeInfo()
                            .Assembly
                            .GetName()
                            .Name);
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 15,
                        maxRetryDelay: TimeSpan.FromSeconds(15),
                        errorNumbersToAdd: null);
                });
        });

        return services;
    }
}