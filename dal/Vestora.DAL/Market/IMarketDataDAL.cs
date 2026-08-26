
namespace Vestora.DAL.Market;

public interface IMarketDataDAL
{
    Task<List<MarketData>> GetMarketDataAsync(
        long securityId,
        DateOnly? fromDate,
        DateOnly? toDate);
}