using Vestora.Api;
using Serilog;
using Vestora.Api.Middleware;

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

app.UseMiddleware<RequestLoggingMiddleware>();

startup.Configure(app);

app.Run();
