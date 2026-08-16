using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vestora.DAL.Entities;

namespace Vestora.DAL.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  public void Configure(
      EntityTypeBuilder<User> builder)
  {
    builder.ToTable("USR_USER");

    builder.HasKey(x => x.UserId);

    builder.Property(x => x.UserId)
        .HasColumnName("USER_ID")
        .ValueGeneratedOnAdd();

    builder.Property(x => x.Email)
        .HasColumnName("EMAIL")
        .HasMaxLength(320)
        .IsRequired();

    builder.HasIndex(x => x.Email)
        .IsUnique();

    builder.Property(x => x.PhoneNumber)
        .HasColumnName("PHONE_NUMBER")
        .HasMaxLength(20);

    builder.Property(x => x.PasswordHash)
        .HasColumnName("PASSWORD_HASH")
        .IsRequired();

    builder.Property(x => x.FirstName)
        .HasColumnName("FIRST_NAME")
        .HasMaxLength(100)
        .IsRequired();

    builder.Property(x => x.MiddleName)
        .HasColumnName("MIDDLE_NAME")
        .HasMaxLength(100);

    builder.Property(x => x.LastName)
        .HasColumnName("LAST_NAME")
        .HasMaxLength(100)
        .IsRequired();

    builder.Property(x => x.DateOfBirth)
        .HasColumnName("DATE_OF_BIRTH");

    builder.Property(x => x.IsActive)
        .HasColumnName("IS_ACTIVE")
        .IsRequired();

    builder.Property(x => x.EmailVerified)
        .HasColumnName("EMAIL_VERIFIED")
        .IsRequired();

    builder.Property(x => x.PhoneVerified)
        .HasColumnName("PHONE_VERIFIED")
        .IsRequired();

    builder.Property(x => x.CreatedAt)
        .HasColumnName("CREATED_AT")
        .IsRequired();

    builder.Property(x => x.UpdatedAt)
        .HasColumnName("UPDATED_AT")
        .IsRequired();

    builder.Property(x => x.LastLoginAt)
        .HasColumnName("LAST_LOGIN_AT");
  }
}