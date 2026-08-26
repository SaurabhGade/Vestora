namespace Vestora.DTO.Market;

public class GetSecurityResponseDTO
{
    public long SecurityId { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public string? Isin { get; set; }

    public string Exchange { get; set; } = string.Empty;

    public string SecurityType { get; set; } = string.Empty;

    public string? Sector { get; set; }

    public string? Industry { get; set; }

    public bool IsActive { get; set; }
}