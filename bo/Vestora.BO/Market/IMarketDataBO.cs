using Vestora.DTO.Market;

namespace Vestora.BO.Market;

public interface IMarketDataBO
{
    Task<GetMarketDataResponseDTO>GetMarketDataAsync(GetMarketDataRequestDTO i_objGetMarketDataRequestDTO);
}