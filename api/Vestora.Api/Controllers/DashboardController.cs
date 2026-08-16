using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vestora.BO.Dashboard;
using Vestora.DTO.Common;
using Vestora.DTO.Dashboard;

namespace Vestora.Api.Controllers;

[ApiController]
[Route("api/dashboard")]
[Authorize]
public class DashboardController : ControllerBase
{
  private readonly IDashboardBO m_ojbIDashboardBO;

  public DashboardController(
      IDashboardBO i_ojbIDashboardBO)
  {
    m_ojbIDashboardBO = i_ojbIDashboardBO;
  }

  [HttpGet("getUser")]
  public async Task<IActionResult> GetUser()
  {
    var userIdClaim =
        User.FindFirstValue(
            ClaimTypes.NameIdentifier);

    if (!long.TryParse(
            userIdClaim,
            out var userId))
    {
      return Unauthorized();
    }

    var request =
        new GetUserRequestDTO
        {
          SessionObject =
                new SessionObjectDTO
                {
                  UserId = userId,

                  Username =
                        User.FindFirstValue(
                            ClaimTypes.Name),

                  Email =
                        User.FindFirstValue(
                            ClaimTypes.Email),

                  FirstName =
                        User.FindFirstValue(
                            "FirstName"),

                  LastName =
                        User.FindFirstValue(
                            "LastName"),

                  IpAddress =
                        HttpContext.Connection
                            .RemoteIpAddress?
                            .ToString(),

                  UserAgent =
                        Request.Headers
                            .UserAgent
                            .ToString()
                }
        };

    var response =
        await m_ojbIDashboardBO.GetUserAsync(request);

    if (response == null)
    {
      return NotFound();
    }

    return Ok(response);
  }
}