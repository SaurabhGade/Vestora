using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Data.Configurations;

public class ConfigSettingConfiguration
    : IEntityTypeConfiguration<ConfigSetting>
{
    public void Configure(EntityTypeBuilder<ConfigSetting> i_objEntityTypeBuilder)
    {
        i_objEntityTypeBuilder.ToTable("COM_CONFIGSETTINGS");

        i_objEntityTypeBuilder.HasKey(x => x.ConfigId);

        i_objEntityTypeBuilder.Property(x => x.ConfigId)
            .HasColumnName("CONFIG_ID");

        i_objEntityTypeBuilder.Property(x => x.ConfigKey)
            .HasColumnName("CONFIG_KEY")
            .HasMaxLength(100)
            .IsRequired();

        i_objEntityTypeBuilder.Property(x => x.ConfigValue)
            .HasColumnName("CONFIG_VALUE");

        i_objEntityTypeBuilder.Property(x => x.ConfigType)
            .HasColumnName("CONFIG_TYPE")
            .HasMaxLength(30)
            .IsRequired();

        i_objEntityTypeBuilder.Property(x => x.Description)
            .HasColumnName("DESCRIPTION")
            .HasMaxLength(500);

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

        i_objEntityTypeBuilder.HasIndex(x => x.ConfigKey)
            .IsUnique();
    }
}