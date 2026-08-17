using Vestora.Api;
using Serilog;
using Vestora.Api.Middleware;
using Vestora.DAL.Dashboard;
using Vestora.BO.Dashboard;


/// Author: Saurabh Gade
/// Inject DI from here
void addSerives(IServiceCollection i_objIServiceCollection)
{
    i_objIServiceCollection.AddScoped<IDashboardDAL, DashboardDAL>();
    i_objIServiceCollection.AddScoped<IDashboardBO, DashboardBO>();
}

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

var startup = new Startup(
    builder.Configuration,
    builder.Environment);

addSerives(builder.Services);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();

startup.Configure(app);

app.Run();
