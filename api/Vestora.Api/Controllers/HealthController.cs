using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vestora.DAL.Data;

namespace Vestora.Api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    private readonly VestoraDbContext _dbContext;

    public HealthController(VestoraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("database")]
    public async Task<IActionResult> Database()
    {
        var canConnect = await _dbContext.Database.CanConnectAsync();

        return Ok(new
        {
            Database = "PostgreSQL",
            Connected = canConnect
        });
    }
}
