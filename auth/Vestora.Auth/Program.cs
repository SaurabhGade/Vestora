/// <summary>
/// Author: Saurabh Gade
/// Date: Aug 16 2026
/// Initial Cookie-based Authentication setup
/// </summary>

using Vestora.Auth;
using Serilog;
using Vestora.DAL.Users;
using Microsoft.AspNetCore.Identity;
using Vestora.DAL.Entities;
using Vestora.BO.Users;


/// Author: Saurabh Gade
/// Inject DI from here
void addSerives(IServiceCollection i_objIServiceCollection)
{
    i_objIServiceCollection.AddScoped<IUserDAL, UserDAL>();
    i_objIServiceCollection.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
    i_objIServiceCollection.AddScoped<IUserBO, UserBO>();
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

startup.Configure(app);

app.Run();
