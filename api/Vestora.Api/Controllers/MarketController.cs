using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vestora.BO.Market;
using Vestora.DTO.Common;
using Vestora.DTO.Market;

namespace Vestora.Api.Controllers;

[ApiController]
[Route("api/market")]
[Authorize]
public class MarketController : ControllerBase
{
    private readonly IMarketBO m_objIMarketBO;
    private readonly IMarketDataBO m_objIMarketDataBO;

    public MarketController(IMarketBO i_ojbIMarketBO, IMarketDataBO i_objIMarketDataBO)
    {
        m_objIMarketBO = i_ojbIMarketBO;
        m_objIMarketDataBO = i_objIMarketDataBO;
    }

    [HttpPost("getSecurities")]
    public async Task<IActionResult> GetSecurities([FromBody] GetSecuritiesRequestDTO request)
    {
        var response = await m_objIMarketBO.GetSecuritiesAsync(request);

        return Ok(
            new BaseResponseDTO<GetSecuritiesResponseDTO> { IsSuccess = true, Response = response }
        );
    }

    [HttpPost("GetMarketData")]
    public async Task<IActionResult> GetMarketData(
        [FromBody] GetMarketDataRequestDTO i_objGetMarketDataRequestDTO
    )
    {
        var response = await m_objIMarketDataBO.GetMarketDataAsync(i_objGetMarketDataRequestDTO);

        return Ok(
            new BaseResponseDTO<GetMarketDataResponseDTO> { IsSuccess = true, Response = response }
        );
    }
}
