using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Users.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration config)
    {
        Configuration = config;
    }

    public virtual IServiceCollection ConfigureServices(IServiceCollection services)
    {
        services
            .AddCustomMvc(Configuration)
            .AddCustomDbContext(Configuration);

        return services;
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
        services.AddDbContext<UserContext>(options =>
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