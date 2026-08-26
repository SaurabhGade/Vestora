using Microsoft.EntityFrameworkCore;

using Vestora.DAL.Data;

namespace Vestora.DAL.Market;

public class MarketDataDAL : IMarketDataDAL
{
  private readonly VestoraDbContext m_objVestoraDbContext;

  public MarketDataDAL(
      VestoraDbContext dbContext)
  {
    m_objVestoraDbContext = dbContext;
  }

  public async Task<List<MarketData>> GetMarketDataAsync(long securityId, DateOnly? fromDate, DateOnly? toDate)
  {
    var query = m_objVestoraDbContext.MarketData
        .AsNoTracking()
        .Where(x =>
            x.SecurityId == securityId);

    if (fromDate.HasValue)
    {
      query = query.Where(x =>
          x.TradeDate >= fromDate.Value);
    }

    if (toDate.HasValue)
    {
      query = query.Where(x =>
          x.TradeDate <= toDate.Value);
    }

    return await query
        .OrderBy(x => x.TradeDate)
        .ToListAsync();
  }
}