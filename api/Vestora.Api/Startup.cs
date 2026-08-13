using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Configuration;
using Vestora.DAL.Data;

namespace Vestora.Api;

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
        // -------------------------
        // Database configuration
        // -------------------------

        var databaseConfig =
            LoadDatabaseConfig();

        services.AddSingleton(databaseConfig);

        var connectionString =
            DatabaseConnectionFactory.Create(databaseConfig);

        services.AddDbContext<VestoraDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        // -------------------------
        // Controllers
        // -------------------------

        services.AddControllers();

        // -------------------------
        // Swagger
        // -------------------------

    }

    public void Configure(WebApplication app)
    {
//       if (app.Environment.IsDevelopment())
//       {
//           app.UseSwagger();
//           app.UseSwaggerUI();
//       }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }

    private DatabaseConfig LoadDatabaseConfig()
    {
        var relativePath =
            _configuration["Config:DatabaseConfigPath"];

        if (string.IsNullOrWhiteSpace(relativePath))
        {
            throw new InvalidOperationException(
                "DatabaseConfigPath is not configured.");
        }

        var fullPath = Path.GetFullPath(
            Path.Combine(
                _environment.ContentRootPath,
                relativePath));

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
