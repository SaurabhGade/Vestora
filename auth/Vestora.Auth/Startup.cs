using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Configuration;
using Vestora.DAL.Data;

namespace Vestora.Auth;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(
        IConfiguration configuration,
        IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // -----------------------------------------
        // Database Configuration
        // -----------------------------------------

        var databaseConfig = LoadDatabaseConfig();

        services.AddSingleton(databaseConfig);

        var connectionString =
            DatabaseConnectionFactory.Create(databaseConfig);

        services.AddDbContext<VestoraDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        // -----------------------------------------
        // MVC Controllers
        // -----------------------------------------

        services.AddControllers();

        // -----------------------------------------
        // Razor Pages
        // -----------------------------------------

        services.AddRazorPages();

        // -----------------------------------------
        // Authentication
        // -----------------------------------------
        // We will configure the actual authentication
        // scheme/cookie here later.

        // services.AddAuthentication(...);

        // -----------------------------------------
        // Authorization
        // -----------------------------------------

        services.AddAuthorization();
    }

    public void Configure(WebApplication app)
    {
        // -----------------------------------------
        // Development
        // -----------------------------------------

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // -----------------------------------------
        // Routing
        // -----------------------------------------

        app.UseRouting();

        // -----------------------------------------
        // Authentication
        // -----------------------------------------
        // Will be enabled when we implement login.

        // app.UseAuthentication();

        // -----------------------------------------
        // Authorization
        // -----------------------------------------

        app.UseAuthorization();

        // -----------------------------------------
        // Controllers
        // -----------------------------------------

        app.MapControllers();

        // -----------------------------------------
        // Razor Pages
        // -----------------------------------------

        app.MapRazorPages();
    }

    private DatabaseConfig LoadDatabaseConfig()
    {
        var relativePath =
            _configuration["Config:DatabaseConfigPath"];

        if (string.IsNullOrWhiteSpace(relativePath))
        {
            throw new InvalidOperationException(
                "Config:DatabaseConfigPath is not configured.");
        }

        var fullPath = Path.GetFullPath(
            Path.Combine(
                _environment.ContentRootPath,
                relativePath));

        Console.WriteLine(
            $"Database config path: {fullPath}");

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException(
                $"Database configuration file not found: {fullPath}");
        }

        var config = new ConfigurationBuilder()
            .AddJsonFile(
                fullPath,
                optional: false,
                reloadOnChange: true)
            .Build();

        var databaseConfig =
            config.GetSection("Database")
                  .Get<DatabaseConfig>();

        if (databaseConfig == null)
        {
            throw new InvalidOperationException(
                "Database configuration is invalid.");
        }

        return databaseConfig;
    }
}
