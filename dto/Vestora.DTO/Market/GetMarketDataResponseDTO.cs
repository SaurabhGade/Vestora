namespace Vestora.DTO.Market;

public class GetMarketDataResponseDTO
{
    public long SecurityId { get; set; }

    public List<MarketDataDTO> Items { get; set; } = [];
}