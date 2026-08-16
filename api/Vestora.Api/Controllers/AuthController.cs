using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vestora.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    [Authorize]
    [HttpGet("me")]
    public IActionResult GetCurrentUser()
    {
        var userId =
            User.FindFirstValue(
                ClaimTypes.NameIdentifier);

        var email =
            User.FindFirstValue(
                ClaimTypes.Email);

        var firstName =
            User.FindFirstValue(
                ClaimTypes.Name);

        return Ok(new
        {
            authenticated = true,
            userId,
            email,
            firstName
        });
    }
}