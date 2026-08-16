namespace Vestora.DAL.Entities;

public class User
{
  public long UserId { get; set; }

  // Authentication
  public string Email { get; set; } = string.Empty;

  public string? PhoneNumber { get; set; }
  public string PasswordHash { get; set; } = string.Empty;

  // Personal information
  public string FirstName { get; set; } = string.Empty;

  public string? MiddleName { get; set; }

  public string LastName { get; set; } = string.Empty;

  public DateOnly? DateOfBirth { get; set; }

  // Account status
  public bool IsActive { get; set; }

  public bool EmailVerified { get; set; }

  public bool PhoneVerified { get; set; }

  // Audit
  public DateTime CreatedAt { get; set; }

  public DateTime UpdatedAt { get; set; }

  public DateTime? LastLoginAt { get; set; }
}