using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Data.Configurations;

public class SecurityConfiguration : IEntityTypeConfiguration<Security>
{
  public void Configure(EntityTypeBuilder<Security> i_objEntityTypeBuilder)
  {
    i_objEntityTypeBuilder.ToTable("SEC_SECURITY");

    i_objEntityTypeBuilder.HasKey(x => x.SecurityId);

    i_objEntityTypeBuilder.Property(x => x.SecurityId)
        .HasColumnName("SECURITY_ID");

    i_objEntityTypeBuilder.Property(x => x.Symbol)
        .HasColumnName("SYMBOL")
        .HasMaxLength(30)
        .IsRequired();

    i_objEntityTypeBuilder.Property(x => x.CompanyName)
        .HasColumnName("COMPANY_NAME")
        .HasMaxLength(250)
        .IsRequired();

    i_objEntityTypeBuilder.Property(x => x.ISIN)
        .HasColumnName("ISIN")
        .HasMaxLength(20);

    i_objEntityTypeBuilder.Property(x => x.Exchange)
        .HasColumnName("EXCHANGE")
        .HasMaxLength(30)
        .IsRequired();

    i_objEntityTypeBuilder.Property(x => x.SecurityType)
        .HasColumnName("SECURITY_TYPE")
        .HasMaxLength(30)
        .IsRequired();

    i_objEntityTypeBuilder.Property(x => x.Sector)
        .HasColumnName("SECTOR")
        .HasMaxLength(100);

    i_objEntityTypeBuilder.Property(x => x.Industry)
        .HasColumnName("INDUSTRY")
        .HasMaxLength(150);

    i_objEntityTypeBuilder.Property(x => x.IsActive)
        .HasColumnName("IS_ACTIVE")
        .IsRequired();

    i_objEntityTypeBuilder.Property(x => x.CreatedBy)
        .HasColumnName("CREATED_BY");

    i_objEntityTypeBuilder.Property(x => x.CreatedDate)
        .HasColumnName("CREATED_DATE")
        .IsRequired();

    i_objEntityTypeBuilder.Property(x => x.ModifiedBy)
        .HasColumnName("MODIFIED_BY");

    i_objEntityTypeBuilder.Property(x => x.ModifiedDate)
        .HasColumnName("MODIFIED_DATE");

    i_objEntityTypeBuilder.HasIndex(x => new
    {
      x.Symbol,
      x.Exchange
    })
    .IsUnique();
  }
}