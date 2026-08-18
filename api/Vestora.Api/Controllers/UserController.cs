using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Vestora.BO.Users;
using Vestora.DTO.Common;
using Vestora.DTO.Dashboard;

namespace Vestora.Api.Controllers;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserBO m_objIUserBO;

    public UserController(IUserBO i_objIUserBO)
    {
        m_objIUserBO = i_objIUserBO;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
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

        var sessionObject =
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
                    Request.Headers.UserAgent.ToString()
            };

        var request =
            new GetUserRequestDTO
            {
                SessionObject = sessionObject
            };

        var response =
            await m_objIUserBO.GetUserAsync(request);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }
}