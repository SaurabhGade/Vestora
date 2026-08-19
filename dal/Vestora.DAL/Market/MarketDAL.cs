using Microsoft.EntityFrameworkCore;

using Vestora.DAL.Data;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Market;

public class MarketDAL : IMarketDAL
{
  private readonly VestoraDbContext m_objVestoraDbContext;

  public MarketDAL(VestoraDbContext i_objVestoraDbContext)
  {
    m_objVestoraDbContext = i_objVestoraDbContext;
  }

  public async Task<(List<Security> Items, int TotalCount)> GetSecuritiesAsync(string? search, int page, int pageSize)
  {
    var query = m_objVestoraDbContext.Securities
        .AsNoTracking()
        .Where(x => x.IsActive);

    if (!string.IsNullOrWhiteSpace(search))
    {
      search = search.Trim();

      query = query.Where(x =>
          EF.Functions.ILike(
              x.Symbol,
              $"%{search}%")
          ||
          EF.Functions.ILike(
              x.CompanyName,
              $"%{search}%"));
    }

    var totalCount = await query.CountAsync();

    var items = await query
        .OrderBy(x => x.Symbol)
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    return (items, totalCount);
  }
}