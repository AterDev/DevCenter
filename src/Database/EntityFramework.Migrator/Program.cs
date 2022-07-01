using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configBuilder = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", true, true)
    .AddEnvironmentVariables();

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
if (!string.IsNullOrEmpty(env))
{
    configBuilder.AddJsonFile($"appsettings.{env}.json", true, true);
    if (env.Equals("Development"))
    {
        configBuilder.AddUserSecrets(typeof(Program).Assembly);
    }
}

var config = configBuilder.Build();

var host = Host.CreateDefaultBuilder(args)
    .ConfigureDefaults(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<ContextBase>(option =>
        {
            var connectionString = config.GetConnectionString("Default");
            option.UseNpgsql(connectionString, option => option.MigrationsAssembly("EntityFramework.Migrator"));
        });
    });

host.RunConsoleAsync();
