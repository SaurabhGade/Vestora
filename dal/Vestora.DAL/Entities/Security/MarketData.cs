using Vestora.DAL.Entities;

public class MarketData
{
    public long MarketDataId { get; set; }

    public long SecurityId { get; set; }

    public DateOnly TradeDate { get; set; }

    public decimal? OpenPrice { get; set; }

    public decimal? HighPrice { get; set; }

    public decimal? LowPrice { get; set; }

    public decimal? ClosePrice { get; set; }

    public decimal? AdjustedClosePrice { get; set; }

    public decimal? PreviousClosePrice { get; set; }

    public long? Volume { get; set; }

    public decimal? ValueTraded { get; set; }

    public decimal? ChangeValue { get; set; }

    public decimal? ChangePercent { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public Security Security { get; set; } = null!;
}