using Serilog.Context;

namespace Vestora.Api.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate m_objRequestDelegate;

    public RequestLoggingMiddleware(
        RequestDelegate i_objRequestDelegate)
    {
        m_objRequestDelegate = i_objRequestDelegate;
    }

    public async Task InvokeAsync(
        HttpContext context)
    {
        var correlationId =
            context.Request.Headers["X-Correlation-ID"]
                .FirstOrDefault()
            ?? Guid.NewGuid().ToString();

        context.Response.Headers["X-Correlation-ID"] =
            correlationId;

        using (LogContext.PushProperty(
            "CorrelationId",
            correlationId))
        {
            await m_objRequestDelegate(context);
        }
    }
}