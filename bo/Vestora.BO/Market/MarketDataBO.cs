using Microsoft.Extensions.Logging;
using Vestora.DAL.Market;
using Vestora.DTO.Market;

namespace Vestora.BO.Market;

public class MarketDataBO : IMarketDataBO
{
    private readonly IMarketDataDAL m_objIMarketDataDAL;
    private readonly ILogger<MarketDataBO> m_objIlogger;

    public MarketDataBO(ILogger<MarketDataBO> i_objIlogger, IMarketDataDAL i_objIMarketDataDAL)
    {
        m_objIMarketDataDAL = i_objIMarketDataDAL;
        m_objIlogger = i_objIlogger;
    }

    public async Task<GetMarketDataResponseDTO> GetMarketDataAsync(
        GetMarketDataRequestDTO i_objGetMarketDataRequestDTO
    )
    {
        if (i_objGetMarketDataRequestDTO.SecurityId <= 0)
        {
            throw new ArgumentException("SecurityId must be greater than zero.");
        }

        if (
            i_objGetMarketDataRequestDTO.FromDate.HasValue
            && i_objGetMarketDataRequestDTO.ToDate.HasValue
            && i_objGetMarketDataRequestDTO.FromDate > i_objGetMarketDataRequestDTO.ToDate
        )
        {
            throw new ArgumentException("FromDate cannot be greater than ToDate.");
        }

        var data = await m_objIMarketDataDAL.GetMarketDataAsync(
            i_objGetMarketDataRequestDTO.SecurityId,
            i_objGetMarketDataRequestDTO.FromDate,
            i_objGetMarketDataRequestDTO.ToDate
        );

        return new GetMarketDataResponseDTO
        {
            SecurityId = i_objGetMarketDataRequestDTO.SecurityId,

            Items = data.Select(x => new MarketDataDTO
                {
                    TradeDate = x.TradeDate,
                    OpenPrice = x.OpenPrice,
                    HighPrice = x.HighPrice,
                    LowPrice = x.LowPrice,
                    ClosePrice = x.ClosePrice,
                    AdjustedClosePrice = x.AdjustedClosePrice,
                    PreviousClosePrice = x.PreviousClosePrice,
                    Volume = x.Volume,
                    ValueTraded = x.ValueTraded,
                    ChangeValue = x.ChangeValue,
                    ChangePercent = x.ChangePercent,
                })
                .ToList(),
        };
    }
}
