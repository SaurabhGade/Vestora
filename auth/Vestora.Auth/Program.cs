/// <summary>
/// Author: Saurabh Gade
/// Date: Aug 16 2026
/// Initial Cookie-based Authentication setup
/// </summary>

using Vestora.Auth; 
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

var startup = new Startup(
    builder.Configuration,
    builder.Environment);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app);

app.Run();
