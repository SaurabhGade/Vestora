using Vestora.DAL.Entities;

public interface IMarketDAL
{
    Task<(List<Security> Items, int TotalCount)> GetSecuritiesAsync(string? search,int page,int pageSize);
}