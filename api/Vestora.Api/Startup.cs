using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Configuration;
using Vestora.DAL.Data;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Vestora.DAL.Dashboard;
using Vestora.BO.Dashboard;

namespace Vestora.Api;

public class Startup
{
    private readonly IConfiguration m_objIConfiguration;
    private readonly IWebHostEnvironment m_objIWebHostEnvironment;

    public Startup(
        IConfiguration i_objIConfiguration,
        IWebHostEnvironment i_objIWebHostEnvironment)
    {
        m_objIConfiguration = i_objIConfiguration;
        m_objIWebHostEnvironment = i_objIWebHostEnvironment;
    }

    public void ConfigureServices(IServiceCollection i_objIServiceCollection)
    {
        // -------------------------
        // Database configuration
        // -------------------------
        
        var dataProtectionPath = Path.GetFullPath(
            Path.Combine(
                m_objIWebHostEnvironment.ContentRootPath,
                "../../config/DataProtectionKeys"));
        
        i_objIServiceCollection
            .AddDataProtection()
            .PersistKeysToFileSystem(
                new DirectoryInfo(dataProtectionPath))
            .SetApplicationName("Vestora");

        var databaseConfig =
            LoadDatabaseConfig();

        /// Inject DI
        i_objIServiceCollection.AddScoped<IDashboardDAL, DashboardDAL>();
        i_objIServiceCollection.AddScoped<IDashboardBO, DashboardBO>();


        i_objIServiceCollection.AddSingleton(databaseConfig);

        var connectionString =
            DatabaseConnectionFactory.Create(databaseConfig);

        i_objIServiceCollection.AddDbContext<VestoraDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        i_objIServiceCollection
            .AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "Vestora.Auth";

                options.Cookie.HttpOnly = true;

                options.Cookie.SameSite = SameSiteMode.Lax;

                options.Cookie.SecurePolicy =
                    CookieSecurePolicy.None;

                options.Cookie.Path = "/";

                options.ExpireTimeSpan =
                    TimeSpan.FromHours(8);

                options.SlidingExpiration = true;

                options.Events.OnRedirectToLogin =
                    context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    };

                options.Events.OnRedirectToAccessDenied =
                    context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        return Task.CompletedTask;
                    };
            });
        
        i_objIServiceCollection.AddAuthorization();
        
        i_objIServiceCollection.AddCors(options =>
        {
            options.AddPolicy("VestoraUI", policy =>
            {
                policy
                    .WithOrigins("http://localhost:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        // -------------------------
        // Controllers
        // -------------------------

        i_objIServiceCollection.AddControllers();

        // -------------------------
        // Swagger
        // -------------------------

    }

    public void Configure(WebApplication i_objWebApplication)
    {    if (i_objWebApplication.Environment.IsDevelopment())
        {
            i_objWebApplication.UseDeveloperExceptionPage();
        }

        i_objWebApplication.UseRouting();

        i_objWebApplication.UseCors("VestoraUI");

        i_objWebApplication.UseAuthentication();

        i_objWebApplication.UseAuthorization();

        i_objWebApplication.MapControllers();
    }

    private DatabaseConfig LoadDatabaseConfig()
    {
        var relativePath =
            m_objIConfiguration["Config:DatabaseConfigPath"];

        if (string.IsNullOrWhiteSpace(relativePath))
        {
            throw new InvalidOperationException(
                "DatabaseConfigPath is not configured.");
        }

        var fullPath = Path.GetFullPath(
            Path.Combine(
                m_objIWebHostEnvironment.ContentRootPath,
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
