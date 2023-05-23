using Microsoft.EntityFrameworkCore;
using Users.Infrastructure;

namespace Users.API;

public class Startup
{
    private readonly IConfiguration _config;

    public Startup(
        IConfiguration config)
    {
        _config = config;

        if (config is null)
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddCustomMvc(_config)
            .AddSwaggerGen()
            .AddCustomDbContext(_config);
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new ApplicationModule(_config.GetConnectionString("mssql")!));
        builder.RegisterModule(new MetiatorModule());
        builder.RegisterModule(new DomainEventMediatorModule());
    }

    public void Configure(
        IApplicationBuilder app, 
        IHostEnvironment env, 
        ILoggerFactory loggerFactory,
        IServiceScopeFactory serviceScopeFactory)
    {
        DomainEventMediatorModule.ServiceScopeFactory = serviceScopeFactory;

        var pathBase = _config["PATH_BASE"];
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
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
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
                        .WithOrigins(config["Cors:Origins"] ?? "https://localhost"));
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
                    var migrationAssemblyName =
                        typeof(UsersContext)
                            .GetTypeInfo()
                            .Assembly
                            .GetName()
                            .Name;
                    sqlOptions.MigrationsAssembly(migrationAssemblyName);

                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 15,
                        maxRetryDelay: TimeSpan.FromSeconds(15),
                        errorNumbersToAdd: null);
                });
        });

        return services;
    }
}