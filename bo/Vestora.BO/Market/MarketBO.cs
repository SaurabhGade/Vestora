using Vestora.DAL.Market;
namespace Vestora.BO.Market;

public class MarketBO : IMarketBO
{
  private readonly IMarketDAL m_objIMarketDAL;

  public MarketBO(IMarketDAL i_objMarketDAL)
  {
    m_objIMarketDAL = i_objMarketDAL;
  }

  public async Task<GetSecuritiesResponseDTO> GetSecuritiesAsync(GetSecuritiesRequestDTO i_objGetSecuritiesRequestDTO)
  {
    var page =
        i_objGetSecuritiesRequestDTO.Page <= 0 ? 1 : i_objGetSecuritiesRequestDTO.Page;

    var pageSize =
        i_objGetSecuritiesRequestDTO.PageSize <= 0 ? 25 : Math.Min(i_objGetSecuritiesRequestDTO.PageSize, 100);

    var result =
        await m_objIMarketDAL.GetSecuritiesAsync(
            i_objGetSecuritiesRequestDTO.Search,
            page,
            pageSize);

    var totalPages =
        result.TotalCount == 0 ? 0 : (int)Math.Ceiling(result.TotalCount / (double)pageSize);

    return new GetSecuritiesResponseDTO
    {
      Items = result.Items
            .Select(x => new SecurityDTO
            {
              SecurityId = x.SecurityId,
              Symbol = x.Symbol,
              CompanyName = x.CompanyName,
              ISIN = x.ISIN ?? "",
              Exchange = x.Exchange ?? "",
              SecurityType = x.SecurityType,
              Sector = x.Sector ?? "",
              Industry = x.Industry ?? "",
              IsActive = x.IsActive
            }).ToList(),

      TotalCount = result.TotalCount,
      Page = page,
      PageSize = pageSize,
      TotalPages = totalPages
    };
  }
}