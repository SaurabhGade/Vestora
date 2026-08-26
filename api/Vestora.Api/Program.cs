using Vestora.Api;
using Serilog;
using Vestora.Api.Middleware;
using Vestora.DAL.Dashboard;
using Vestora.BO.Dashboard;
using Vestora.BO.Users;
using Vestora.DAL.Users;
using Microsoft.AspNetCore.Identity;
using Vestora.DAL.Entities;
using Vestora.DAL.Config;
using Vestora.BO.Config;
using Vestora.BO.Market;
using Vestora.DAL.Market;


/// Author: Saurabh Gade
/// Inject DI from here
void addSerives(IServiceCollection i_objIServiceCollection)
{
    i_objIServiceCollection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

    i_objIServiceCollection.AddScoped<IDashboardBO, DashboardBO>();
    i_objIServiceCollection.AddScoped<IDashboardDAL, DashboardDAL>();

    i_objIServiceCollection.AddScoped<IUserBO, UserBO>();
    i_objIServiceCollection.AddScoped<IUserDAL, UserDAL>();

    i_objIServiceCollection.AddScoped<IConfigBO, ConfigBO>();
    i_objIServiceCollection.AddScoped<IConfigDAL, ConfigDAL>();

    i_objIServiceCollection.AddScoped<IMarketBO, MarketBO>();
    i_objIServiceCollection.AddScoped<IMarketDAL, MarketDAL>();

    i_objIServiceCollection.AddScoped<IMarketDataBO, MarketDataBO>();
    i_objIServiceCollection.AddScoped<IMarketDataDAL, MarketDataDAL>();
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
