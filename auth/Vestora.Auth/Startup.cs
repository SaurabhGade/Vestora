using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Configuration;
using Vestora.DAL.Data;

namespace Vestora.Auth;

public class Startup
{
    /// <summary>
    /// Author: Saurabh Gade
    /// Date: Aug 16 2026
    /// Initial Cookie-based Authentication setup
    /// </summary>
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
        DatabaseConfig objDatabaseConfig = LoadDatabaseConfig();

        i_objIServiceCollection.AddSingleton(objDatabaseConfig);

        string sConnectionString =
            DatabaseConnectionFactory.Create(objDatabaseConfig);

        i_objIServiceCollection.AddDbContext<VestoraDbContext>(options =>
        {
            options.UseNpgsql(sConnectionString);
        });

        i_objIServiceCollection.AddControllers();

        i_objIServiceCollection.AddRazorPages();

        // Cookie Authentication
        i_objIServiceCollection
            .AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";

                options.Cookie.Name = "Vestora.Auth";

                options.Cookie.HttpOnly = true;

                // Development only because we're currently using HTTP.
                options.Cookie.SecurePolicy =
                    CookieSecurePolicy.None;

                options.Cookie.SameSite =
                    SameSiteMode.Lax;

                options.ExpireTimeSpan =
                    TimeSpan.FromHours(8);

                options.SlidingExpiration = true;
            });

        i_objIServiceCollection.AddAuthorization();
    }

    public void Configure(WebApplication i_objWebApplication)
    {
        if (i_objWebApplication.Environment.IsDevelopment())
        {
            i_objWebApplication.UseDeveloperExceptionPage();
        }

        i_objWebApplication.UseRouting();

        // IMPORTANT:
        // Authentication must come before Authorization.

        i_objWebApplication.UseAuthentication();

        i_objWebApplication.UseAuthorization();

        i_objWebApplication.MapControllers();

        i_objWebApplication.MapRazorPages();
        // catch root requests and bounce them to the Login page
        i_objWebApplication.MapGet("/", context =>
        {
            context.Response.Redirect("/Login");
            return Task.CompletedTask;
        });
    }

    private DatabaseConfig LoadDatabaseConfig()
    {

        string? relativePath =
            m_objIConfiguration["Config:DatabaseConfigPath"];

        if (string.IsNullOrWhiteSpace(relativePath))
        {
            throw new InvalidOperationException(
                "Config:DatabaseConfigPath is not configured.");
        }

        string fullPath = Path.GetFullPath(
            Path.Combine(
                m_objIWebHostEnvironment.ContentRootPath,
                relativePath));

        if (!File.Exists(fullPath))
        {
            throw new FileNotFoundException(
                $"Database configuration file not found: {fullPath}");
        }

        IConfigurationRoot objIConfigurationRoot = new ConfigurationBuilder()
            .AddJsonFile(
                fullPath,
                optional: false,
                reloadOnChange: true)
            .Build();

        DatabaseConfig? objDatabaseConfig =
            objIConfigurationRoot
                .GetSection("Database")
                .Get<DatabaseConfig>();

        if (objDatabaseConfig == null)
        {
            throw new InvalidOperationException(
                "Database configuration is invalid.");
        }

        return objDatabaseConfig;
    }
}