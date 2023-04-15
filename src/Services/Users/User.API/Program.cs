var config = GetConfiguration();

var host = CreateHostBuilder(config, args).Build();

host.Run();

return 0;

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

IHostBuilder CreateHostBuilder(IConfiguration configuration, string[] args) =>
    Host.CreateDefaultBuilder(args)
        .UseServiceProviderFactory(new AutofacServiceProviderFactory())
        .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
        });