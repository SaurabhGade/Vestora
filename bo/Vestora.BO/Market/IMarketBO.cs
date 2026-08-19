namespace Vestora.BO.Market;

public interface IMarketBO
{
    Task<GetSecuritiesResponseDTO> GetSecuritiesAsync(GetSecuritiesRequestDTO request);
}