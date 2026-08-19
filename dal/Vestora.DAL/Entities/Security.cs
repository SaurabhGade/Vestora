namespace Vestora.DAL.Entities;

public class Security
{
      /// <summary>
    /// Author: Saurabh Gade
    /// SEC_SECURITY Table for migration
    /// </summary>
  public long SecurityId { get; set; }

  public string Symbol { get; set; } = string.Empty;

  public string CompanyName { get; set; } = string.Empty;

  public string? ISIN { get; set; }

  public string Exchange { get; set; } = string.Empty;

  public string SecurityType { get; set; } = string.Empty;

  public string? Sector { get; set; }

  public string? Industry { get; set; }

  public bool IsActive { get; set; }

  public long? CreatedBy { get; set; }

  public DateTime CreatedDate { get; set; }

  public long? ModifiedBy { get; set; }

  public DateTime? ModifiedDate { get; set; }
}