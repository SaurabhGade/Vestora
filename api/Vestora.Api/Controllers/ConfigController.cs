using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Vestora.BO.Config;

namespace Vestora.Api.Controllers;

[ApiController]
[Route("api/config")]
[Authorize]
public class ConfigController : ControllerBase
{
  private readonly IConfigBO m_objIConfigBO;

  public ConfigController(IConfigBO i_objIConfigBO)
  {
    m_objIConfigBO = i_objIConfigBO;
  }

  [HttpGet("menu")]
  public async Task<IActionResult> GetMenu()
  {
    var menus = await m_objIConfigBO.GetMenuAsync();

    return Ok(menus);
  }
}