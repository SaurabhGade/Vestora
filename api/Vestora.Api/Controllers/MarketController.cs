using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Vestora.BO.Market;
using Vestora.DTO.Common;

namespace Vestora.Api.Controllers;

[ApiController]
[Route("api/market")]
[Authorize]
public class MarketController : ControllerBase
{
    private readonly IMarketBO m_objIMarketBO;

    public MarketController(IMarketBO i_ojbIMarketBO)
    {
        m_objIMarketBO = i_ojbIMarketBO;
    }

    [HttpPost("getSecurities")]
    public async Task<IActionResult> GetSecurities(
        [FromBody] GetSecuritiesRequestDTO request)
    {
        var response =
            await m_objIMarketBO.GetSecuritiesAsync(request);

        return Ok(
            new BaseResponseDTO<GetSecuritiesResponseDTO>
            {
                IsSuccess = true,
                Response = response
            });
    }
}