using Vestora.DTO.Common;

namespace Vestora.DTO.Market;

public class GetMarketDataRequestDTO : BaseRequestDTO
{
    public long SecurityId { get; set; }

    public DateOnly? FromDate { get; set; }

    public DateOnly? ToDate { get; set; }
}