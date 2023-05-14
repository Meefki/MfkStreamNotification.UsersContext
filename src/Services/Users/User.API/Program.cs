var config = GetConfiguration();

Log.Logger = CreateSerilogLogger(config);

try
{
    Log.Information("Configuring host ({ApplicationContext})", Program.AppName);
    var host = CreateHostBuilder(config, args).Build();

    Log.Information("Appying migrations ({ApplicationName})", Program.AppName);
    using (var scope = host.Services.CreateScope())
    {
        using (var appContext = scope.ServiceProvider.GetRequiredService<UsersContext>())
        {
            try
            {
                appContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Migration proccess failed ({ApplicationName})", Program.AppName);
            }
        }
    }

    Log.Information("Starting host ({ApplicationContext})...", Program.AppName);
    host.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", Program.AppName);
}
finally
{
    Log.CloseAndFlush();
}

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile(GetAppSettingsFileName(), optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

string GetAppSettingsFileName()
{
    string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

    return env switch
    {
        "Production" => "appsettings.json",
        _ => $"appsettings.{env}.json"
    };
}

IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
        })
        .UseSerilog(Log.Logger);

Serilog.ILogger CreateSerilogLogger(IConfiguration config)
{
    var seqServerUrl = config["Serilog:SeqServerUrl"];
    return new LoggerConfiguration()
        .MinimumLevel.Verbose()
        .Enrich.WithProperty("ApplicationName", Program.AppName)
        .Enrich.FromLogContext()
        .WriteTo.Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
        .WriteTo.Console()
        .ReadFrom.Configuration(config)
        .CreateLogger();
}

public partial class Program
{
    public static string Namespace = typeof(Startup).Namespace!;
    public static string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
}