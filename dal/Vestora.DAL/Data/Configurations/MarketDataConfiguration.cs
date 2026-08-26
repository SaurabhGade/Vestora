using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vestora.DAL.Data.Configurations;

public class MarketDataConfiguration : IEntityTypeConfiguration<MarketData>
{
  public void Configure(EntityTypeBuilder<MarketData> builder)
  {
    builder.ToTable("SEC_MARKET_DATA");

    builder.HasKey(x => x.MarketDataId)
        .HasName("PK_SEC_MARKET_DATA");

    builder.Property(x => x.MarketDataId)
        .HasColumnName("MARKET_DATA_ID")
        .ValueGeneratedOnAdd();

    builder.Property(x => x.SecurityId)
        .HasColumnName("SECURITY_ID")
        .IsRequired();

    builder.Property(x => x.TradeDate)
        .HasColumnName("TRADE_DATE")
        .IsRequired();

    builder.Property(x => x.OpenPrice)
        .HasColumnName("OPEN_PRICE")
        .HasPrecision(20, 6);

    builder.Property(x => x.HighPrice)
        .HasColumnName("HIGH_PRICE")
        .HasPrecision(20, 6);

    builder.Property(x => x.LowPrice)
        .HasColumnName("LOW_PRICE")
        .HasPrecision(20, 6);

    builder.Property(x => x.ClosePrice)
        .HasColumnName("CLOSE_PRICE")
        .HasPrecision(20, 6);

    builder.Property(x => x.AdjustedClosePrice)
        .HasColumnName("ADJUSTED_CLOSE_PRICE")
        .HasPrecision(20, 6);

    builder.Property(x => x.PreviousClosePrice)
        .HasColumnName("PREVIOUS_CLOSE_PRICE")
        .HasPrecision(20, 6);

    builder.Property(x => x.Volume)
        .HasColumnName("VOLUME");

    builder.Property(x => x.ValueTraded)
        .HasColumnName("VALUE_TRADED")
        .HasPrecision(24, 6);

    builder.Property(x => x.ChangeValue)
        .HasColumnName("CHANGE_VALUE")
        .HasPrecision(20, 6);

    builder.Property(x => x.ChangePercent)
        .HasColumnName("CHANGE_PERCENT")
        .HasPrecision(12, 6);

    builder.Property(x => x.CreatedDate)
        .HasColumnName("CREATED_DATE")
        .HasDefaultValueSql("CURRENT_TIMESTAMP")
        .IsRequired();

    builder.Property(x => x.ModifiedDate)
        .HasColumnName("MODIFIED_DATE");

    builder.HasOne(x => x.Security)
        .WithMany()
        .HasForeignKey(x => x.SecurityId)
        .HasConstraintName("FK_SEC_MARKET_DATA_SECURITY");

    builder.HasIndex(x => new
    {
      x.SecurityId,
      x.TradeDate
    }).IsUnique().HasDatabaseName("UQ_SEC_MARKET_DATA_SECURITY_DATE");
  }
}